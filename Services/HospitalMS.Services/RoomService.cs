namespace HospitalMS.Services
{
    using HospitalMS.Data;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class RoomService : IRoomService
    {
        private readonly HospitalMSDbContext context;

        public RoomService(HospitalMSDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(RoomServiceModel roomServiceModel)
        {
            RoomType roomTypeFromDb =
                context.RoomTypes
                .SingleOrDefault(roomType => roomType.Name == roomServiceModel.RoomType.Name);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            Room room = AutoMapper.Mapper.Map<Room>(roomServiceModel);
            room.RoomType = roomTypeFromDb;

            context.Rooms.Add(room);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreateRoomType(RoomTypeServiceModel roomTypeServiceModel)
        {
            RoomType roomType = new RoomType
            {
                Name = roomTypeServiceModel.Name
            };

            context.RoomTypes.Add(roomType);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<RoomTypeServiceModel> GetAllRoomTypes()
        {
            return this.context.RoomTypes.To<RoomTypeServiceModel>();
        }

        public IQueryable<RoomServiceModel> GetAllRooms()
        {

            return this.context.Rooms.To<RoomServiceModel>();
        }

        public async Task<RoomServiceModel> GetById(string id)
        {
            return await this.context.Rooms
                .To<RoomServiceModel>()
                .SingleOrDefaultAsync(room => room.Id == id);
        }

        public async Task<bool> Edit(string id, RoomServiceModel roomServiceModel)
        {
            RoomType roomTypeFromDb =
                 context.RoomTypes
                 .SingleOrDefault(roomType => roomType.Name == roomServiceModel.RoomType.Name);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            Room roomFromDb = await this.context.Rooms.SingleOrDefaultAsync(room => room.Id == id);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            roomFromDb.Name = roomServiceModel.Name;
            roomFromDb.RoomType.Id = roomTypeFromDb.Id;

            this.context.Rooms.Update(roomFromDb);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            Room roomFromDb = await this.context.Rooms.SingleOrDefaultAsync(room => room.Id == id);

            if (roomFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomFromDb));
            }

            this.context.Rooms.Remove(roomFromDb);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

    }
}
