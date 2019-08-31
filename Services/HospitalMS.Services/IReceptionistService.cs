namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IReceptionistService
    {
        IQueryable<ReceptionistServiceModel> GetAllReceptionists();

        Task<bool> Create(string password, ReceptionistServiceModel receptionistServiceModel);

        Task<ReceptionistServiceModel> GetById(string id);

        Task<bool> Edit(string id, ReceptionistServiceModel receptionistServiceModel);

        Task<bool> Delete(string id);
    }
}
