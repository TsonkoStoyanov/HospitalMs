namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IDoctorService
    {
        IQueryable<DoctorServiceModel> GetAllDoctors();

        Task<bool> Create(string password, DoctorServiceModel doctorServiceModel);

        Task<DoctorServiceModel> GetById(string id);

        Task<bool> Edit(string id, DoctorServiceModel doctorServiceModel);

        Task<bool> Delete(string id);
    }
}
