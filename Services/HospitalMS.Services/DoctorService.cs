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

    public class DoctorService : IDoctorService
    {
        private readonly HospitalMSDbContext context;
        private readonly UserManager<HospitalMSUser> userManager;

        public DoctorService(HospitalMSDbContext context, UserManager<HospitalMSUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IQueryable<DoctorServiceModel> GetAllDoctors()
        {
            return context.Doctors.To<DoctorServiceModel>();
        }

        public async Task<bool> Create(string password, DoctorServiceModel doctorServiceModel)
        {
            var user = new HospitalMSUser { UserName = doctorServiceModel.Email, Email = doctorServiceModel.Email };
            var userCreateResult = await userManager.CreateAsync(user, password);

            if (userCreateResult.Succeeded)
            {
                user.EmailConfirmed = true;
                user.IsFirstLogin = false;

                await userManager.AddToRoleAsync(user, GlobalConstants.DoctorRoleName);
            }

            Department departmentFromDb = await GetDepartmentFromDb(doctorServiceModel);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            doctorServiceModel.HospitalMSUserId = user.Id;

            Doctor doctor = AutoMapper.Mapper.Map<Doctor>(doctorServiceModel);

            doctor.Department = departmentFromDb;
            context.Doctors.Add(doctor);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, DoctorServiceModel doctorServiceModel)
        {
            Department departmentFromDb = await GetDepartmentFromDb(doctorServiceModel);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            Doctor doctorFromDb = await context.Doctors.SingleOrDefaultAsync(doctor => doctor.Id == id);

            if (doctorFromDb == null)
            {
                throw new ArgumentNullException(nameof(doctorFromDb));
            }

            doctorFromDb.FirstName = doctorServiceModel.FirstName;
            doctorFromDb.LastName = doctorServiceModel.LastName;
            doctorFromDb.PhoneNumber = doctorServiceModel.PhoneNumber;
            doctorFromDb.Department = departmentFromDb;


            context.Doctors.Update(doctorFromDb);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<DoctorServiceModel> GetById(string id)
        {
            return await context.Doctors
                 .To<DoctorServiceModel>()
                 .SingleOrDefaultAsync(doctor => doctor.Id == id);
        }

        public async Task<bool> Delete(string id)
        {
            Doctor doctorFromDb = await context.Doctors.SingleOrDefaultAsync(doctor => doctor.Id == id);

            if (doctorFromDb == null)
            {
                throw new ArgumentNullException(nameof(doctorFromDb));
            }

            var userIdentityId = doctorFromDb.HospitalMSUserId;

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

            context.Doctors.Remove(doctorFromDb);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        private Task<Department> GetDepartmentFromDb(DoctorServiceModel doctorServiceModel)
        {
            return context.Departments
                .SingleOrDefaultAsync(department => department.Name == doctorServiceModel.Department.Name);
        }
    }
}

