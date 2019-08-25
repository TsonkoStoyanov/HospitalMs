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
            RoomType roomTypeFromDb = GetRoomTypeFromDb(roomServiceModel);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }
            Department departmentFromDb = GetDepartmentFromDb(roomServiceModel);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            Room room = AutoMapper.Mapper.Map<Room>(roomServiceModel);
            room.RoomType = roomTypeFromDb;
            room.Department = departmentFromDb;

            context.Rooms.Add(room);
            int result = await context.SaveChangesAsync();

            return result > 0;
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
            RoomType roomTypeFromDb = GetRoomTypeFromDb(roomServiceModel);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            Department departmentFromDb = GetDepartmentFromDb(roomServiceModel);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            Room roomFromDb = await this.context.Rooms.SingleOrDefaultAsync(room => room.Id == id);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            roomFromDb.Name = roomServiceModel.Name;
            roomFromDb.RoomType = roomTypeFromDb;
            roomFromDb.Department = roomFromDb.Department;


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

        private RoomType GetRoomTypeFromDb(RoomServiceModel roomServiceModel)
        {
            return context.RoomTypes
                 .SingleOrDefault(roomType => roomType.Name == roomServiceModel.RoomType.Name);
        }
        private Department GetDepartmentFromDb(RoomServiceModel roomServiceModel)
        {
            return context.Departments
                .SingleOrDefault(department => department.Name == roomServiceModel.Department.Name);
        }
    }
}
