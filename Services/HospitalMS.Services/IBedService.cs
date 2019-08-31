namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Threading.Tasks;


    public interface IBedService
    {
        Task<BedServiceModel> GetById(int id);

        Task<bool> Create(string roomId, BedServiceModel bedServiceModel);

        Task<bool> Edit(int id, BedServiceModel bedServiceModel);

        Task<bool> Remove(string roomId);
    }
}
