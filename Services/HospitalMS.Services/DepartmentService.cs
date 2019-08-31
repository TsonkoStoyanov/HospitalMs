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
            return context.Departments
                .Where(deleted => deleted.IsDeleted == false)
                .Where(status => status.IsActive == true)
                .To<DepartmentServiceModel>();
        }

        public IQueryable<DepartmentServiceModel> GetAllDepartments()
        {
            return context.Departments.Where(deleted => deleted.IsDeleted == false).To<DepartmentServiceModel>();
        }

        public async Task<bool> Create(DepartmentServiceModel departmentServiceModel)
        {
            Hospital hospitalFromDb = await GetHospital(departmentServiceModel);

            if (hospitalFromDb == null)
            {
                throw new ArgumentNullException(nameof(hospitalFromDb));
            }

            var departmentFromDb = await context.Departments.SingleOrDefaultAsync(x => x.Name == departmentServiceModel.Name);

            if (departmentFromDb != null)
            {
                departmentFromDb.Name = departmentServiceModel.Name;
                departmentFromDb.Description = departmentServiceModel.Description;
                departmentFromDb.IsActive = departmentServiceModel.IsActive;
                departmentFromDb.IsDeleted = false;
                departmentFromDb.DeletedOn = null;
                departmentFromDb.Hospital = hospitalFromDb;

                context.Departments.Update(departmentFromDb);

                int result = await context.SaveChangesAsync();

                return result > 0;
            }
            else
            {

                Department department = AutoMapper.Mapper.Map<Department>(departmentServiceModel);

                department.Hospital = hospitalFromDb;

                context.Departments.Add(department);

                int result = await context.SaveChangesAsync();

                return result > 0;
            }
        }

        public async Task<bool> Edit(string id, DepartmentServiceModel departmentServiceModel)
        {
            Hospital hospitalFromDb =
                await GetHospital(departmentServiceModel);

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


            departmentFromDb.IsDeleted = true;
            departmentFromDb.DeletedOn = DateTime.UtcNow;

            context.Departments.Update(departmentFromDb);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<DepartmentServiceModel> GetById(string id)
        {
            return await context.Departments
                 .To<DepartmentServiceModel>()
                 .SingleOrDefaultAsync(department => department.Id == id);
        }

        private async Task<Hospital> GetHospital(DepartmentServiceModel departmentServiceModel)
        {
            return await context.Hospitals
                 .SingleOrDefaultAsync(hospital => hospital.Name == departmentServiceModel.HospitalName);
        }


    }
}
