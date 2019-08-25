using System.Threading.Tasks;
using HospitalMS.Services.Models;

namespace HospitalMS.Services
{
    public class BedService : IBedService
    {
        public Task<bool> Create(BedServiceModel BedServiceModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Edit(int id, BedServiceModel BedServiceModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<BedServiceModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
