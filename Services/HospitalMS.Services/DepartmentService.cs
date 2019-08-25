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

        public async Task<bool> Create(DepartmentServiceModel departmentServiceModel)
        {

            Hospital hospitalFromDb =
                 context.Hospitals
                 .SingleOrDefault(hospital => hospital.Name == departmentServiceModel.HospitalName);

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

        public async Task<bool> Delete(string id)
        {
            Department departmentFromDb = await this.context.Departments.SingleOrDefaultAsync(department => department.Id == id);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            //TODO Cascade Delete if time remains to make warrning has room and users on department before delete
            //if (departmentFromDb.Rooms.Count > 0)
            //{
            //    throw new ArgumentException("Are sure there is rooms related to Department.");
            //}

            //if (departmentFromDb.Users.Count > 0)
            //{
            //    throw new ArgumentException("Are sure there is users related to Department.");
            //}

            this.context.Departments.Remove(departmentFromDb);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, DepartmentServiceModel departmentServiceModel)
        {
            Hospital hospitalFromDb =
                 context.Hospitals
                 .SingleOrDefault(hospital => hospital.Name == departmentServiceModel.HospitalName);

            if (hospitalFromDb == null)
            {
                throw new ArgumentNullException(nameof(hospitalFromDb));
            }

            Department departmentFromDb = await this.context.Departments.SingleOrDefaultAsync(department => department.Id == id);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            departmentFromDb.Name = departmentServiceModel.Name;
            departmentFromDb.Description = departmentServiceModel.Description;
            departmentFromDb.IsActive = departmentServiceModel.IsActive;


            departmentFromDb.Hospital.Id = hospitalFromDb.Id;

            this.context.Departments.Update(departmentFromDb);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<DepartmentServiceModel> GetAllActiveDepartments()
        {
            return this.context.Departments.Where(status => status.IsActive == true).To<DepartmentServiceModel>();
        }

        public IQueryable<DepartmentServiceModel> GetAllDepartments()
        {
            return this.context.Departments.To<DepartmentServiceModel>();
        }

        public async Task<DepartmentServiceModel> GetById(string id)
        {

            return await this.context.Departments
                 .To<DepartmentServiceModel>()
                 .SingleOrDefaultAsync(department => department.Id == id);

        }
    }
}
