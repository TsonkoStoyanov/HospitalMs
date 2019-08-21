namespace HospitalMS.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Data;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Models;

    public class DepartmentService : IDepartmentService
    {
        private readonly HospitalMSDbContext context;

        public DepartmentService(HospitalMSDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Add(DepartmentServiceModel departmentServiceModel)
        {

            Hospital hospitalFromDb =
                 context.Hospitals
                 .SingleOrDefault(hospital => hospital.Name == departmentServiceModel.Hospital.Name);

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

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(string id, DepartmentServiceModel departmentServiceModel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DepartmentServiceModel> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentServiceModel> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
