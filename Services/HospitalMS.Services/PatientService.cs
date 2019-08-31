namespace HospitalMS.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Common;
    using HospitalMS.Data;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;


    public class PatientService : IPatientService
    {
        private readonly HospitalMSDbContext context;
        private readonly UserManager<HospitalMSUser> userManager;

        public PatientService(HospitalMSDbContext context, UserManager<HospitalMSUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<bool> Create(string password, PatientServiceModel patientServiceModel)
        {
            var user = new HospitalMSUser { UserName = patientServiceModel.Email, Email = patientServiceModel.Email };
            var userCreateResult = await userManager.CreateAsync(user, password);

            if (userCreateResult.Succeeded)
            {
                user.EmailConfirmed = true;
                user.IsFirstLogin = false;

                await userManager.AddToRoleAsync(user, GlobalConstants.PatientRoleName);
            }

            Department departmentFromDb = await GetDepartmentFromDb(patientServiceModel);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            patientServiceModel.HospitalMSUserId = user.Id;

            Patient patient = AutoMapper.Mapper.Map<Patient>(patientServiceModel);

            patient.Department = departmentFromDb;
            context.Patients.Add(patient);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            Patient patientFromDb = await context.Patients.SingleOrDefaultAsync(patient => patient.Id == id);

            if (patientFromDb == null)
            {
                throw new ArgumentNullException(nameof(patientFromDb));
            }

            var userIdentityId = patientFromDb.HospitalMSUserId;

            var user = await userManager.FindByIdAsync(userIdentityId);
            var rolesForUser = await userManager.GetRolesAsync(user);

            using (var transaction = context.Database.BeginTransaction())
            {
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        var resultUser = await userManager.RemoveFromRoleAsync(user, item);
                    }
                }

                await userManager.DeleteAsync(user);
                transaction.Commit();
            }

            context.Patients.Remove(patientFromDb);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, PatientServiceModel patientServiceModel)
        {
            Department departmentFromDb = await GetDepartmentFromDb(patientServiceModel);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            Patient patientFromDb = await context.Patients.SingleOrDefaultAsync(patient => patient.Id == id);

            if (patientFromDb == null)
            {
                throw new ArgumentNullException(nameof(patientFromDb));
            }

            patientFromDb.FirstName = patientServiceModel.FirstName;
            patientFromDb.LastName = patientServiceModel.LastName;
            patientFromDb.PhoneNumber = patientServiceModel.PhoneNumber;
            patientFromDb.Address = patientServiceModel.Address;
            patientFromDb.BirthDate = patientServiceModel.BirthDate;           
            patientFromDb.Department = departmentFromDb;


            context.Patients.Update(patientFromDb);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<PatientServiceModel> GetAllPatients()
        {
            return context.Patients.To<PatientServiceModel>();
        }

        public async Task<PatientServiceModel> GetById(string id)
        {
            return await context.Patients
                .To<PatientServiceModel>()
                .SingleOrDefaultAsync(patient => patient.Id == id);
        }

        private Task<Department> GetDepartmentFromDb(PatientServiceModel patientServiceModel)
        {
            return context.Departments
                .SingleOrDefaultAsync(department => department.Name == patientServiceModel.Department.Name);
        }
    }
}
