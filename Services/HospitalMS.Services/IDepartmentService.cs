namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IDepartmentService
    {
        IQueryable<DepartmentServiceModel> GetAllDepartments();

        Task<DepartmentServiceModel> GetById(string id);

        Task<bool> Add(DepartmentServiceModel departmentServiceModel);

        Task<bool> Edit(string id, DepartmentServiceModel departmentServiceModel);

        Task<bool> Delete(string id);

    }
}
