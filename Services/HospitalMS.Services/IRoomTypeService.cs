namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IRoomTypeService
    {
        IQueryable<RoomTypeServiceModel> GetAllRoomTypes();

        Task<bool> CreateRoomType(RoomTypeServiceModel roomTypeServiceModel);

        Task<RoomTypeServiceModel> GetById(int id);

        Task<bool> Edit(int id, RoomTypeServiceModel roomTypeServiceModel);

        Task<bool> Delete(int id);
    }
}
