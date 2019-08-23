namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRoomService
    {
        IQueryable<RoomTypeServiceModel> GetAllRoomTypes();

        IQueryable<RoomServiceModel> GetAllRoom();

        Task<RoomServiceModel> GetById(string id);

        Task<bool> Create(RoomServiceModel roomServiceModel);

        Task<bool> Edit(string id, RoomServiceModel roomServiceModel);

        Task<bool> Delete(string id);

        Task<bool> CreateRoomType(RoomTypeServiceModel roomTypeServiceModel);
    }
}
