using HospitalMS.Services.Models;
using System.Threading.Tasks;

namespace HospitalMS.Services
{
    public interface IHospitalService
    {
        Task<HospitalServiceModel> Get();

        Task<bool> Edit(string id, HospitalServiceModel hospitalServiceModel);
    }
}