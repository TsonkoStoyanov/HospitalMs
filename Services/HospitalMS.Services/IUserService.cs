namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Threading.Tasks;


    public interface IUserService
    {
        Task<HospitalMSUserServiceModel> GetById(string id);
    }
}
