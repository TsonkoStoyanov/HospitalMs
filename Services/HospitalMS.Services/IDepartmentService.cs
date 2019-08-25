namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IDepartmentService
    {
        IQueryable<DepartmentServiceModel> GetAllDepartments();

        IQueryable<DepartmentServiceModel> GetAllActiveDepartments();

        Task<DepartmentServiceModel> GetById(string id);

        Task<bool> Create(DepartmentServiceModel departmentServiceModel);

        Task<bool> Edit(string id, DepartmentServiceModel departmentServiceModel);

        Task<bool> Delete(string id);

    }
}
