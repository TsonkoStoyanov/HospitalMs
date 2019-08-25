namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Threading.Tasks;


    public interface IBedService
    {
        Task<BedServiceModel> GetById(int id);

        Task<bool> Create(BedServiceModel BedServiceModel);

        Task<bool> Edit(int id, BedServiceModel BedServiceModel);

        Task<bool> Delete(int id);
    }
}
