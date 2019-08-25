namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IHospitalService
    {
        Task<HospitalServiceModel> Get();

        Task<bool> Edit(string id, HospitalServiceModel hospitalServiceModel);
        Task<HospitalServiceModel> GetById(string id);

        IQueryable<HospitalServiceModel> GetAllHospitals();
    }
}