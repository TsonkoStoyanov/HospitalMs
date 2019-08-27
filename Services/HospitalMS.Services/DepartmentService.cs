namespace HospitalMS.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Data;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using Microsoft.EntityFrameworkCore;


    public class DepartmentService : IDepartmentService
    {
        private readonly HospitalMSDbContext context;

        public DepartmentService(HospitalMSDbContext context)
        {
            this.context = context;
        }

        public IQueryable<DepartmentServiceModel> GetAllActiveDepartments()
        {
            return context.Departments.Where(status => status.IsActive == true).To<DepartmentServiceModel>();
        }

        public IQueryable<DepartmentServiceModel> GetAllDepartments()
        {
            return context.Departments.To<DepartmentServiceModel>();
        }

        public async Task<bool> Create(DepartmentServiceModel departmentServiceModel)
        {
            Hospital hospitalFromDb = GetHospital(departmentServiceModel);

            if (hospitalFromDb == null)
            {
                throw new ArgumentNullException(nameof(hospitalFromDb));
            }

            Department department = AutoMapper.Mapper.Map<Department>(departmentServiceModel);
            department.Hospital = hospitalFromDb;

            context.Departments.Add(department);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, DepartmentServiceModel departmentServiceModel)
        {
            Hospital hospitalFromDb =
                GetHospital(departmentServiceModel);

            if (hospitalFromDb == null)
            {
                throw new ArgumentNullException(nameof(hospitalFromDb));
            }

            Department departmentFromDb = await context.Departments.SingleOrDefaultAsync(department => department.Id == id);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            departmentFromDb.Name = departmentServiceModel.Name;
            departmentFromDb.Description = departmentServiceModel.Description;
            departmentFromDb.IsActive = departmentServiceModel.IsActive;


            departmentFromDb.Hospital = hospitalFromDb;

            context.Departments.Update(departmentFromDb);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            Department departmentFromDb = await context.Departments.SingleOrDefaultAsync(department => department.Id == id);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            //TODO Cascade Delete if time remains to make warrning has room and users on department before delete

            context.Departments.Remove(departmentFromDb);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<DepartmentServiceModel> GetById(string id)
        {
            return await context.Departments
                 .To<DepartmentServiceModel>()
                 .SingleOrDefaultAsync(department => department.Id == id);
        }

        private Hospital GetHospital(DepartmentServiceModel departmentServiceModel)
        {
            return context.Hospitals
                 .SingleOrDefault(hospital => hospital.Name == departmentServiceModel.HospitalName);
        }


    }
}
