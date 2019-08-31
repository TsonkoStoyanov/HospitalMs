﻿namespace HospitalMS.Services
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
            RoomType roomTypeFromDb = await GetRoomTypeFromDb(roomServiceModel);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            Department departmentFromDb = await GetDepartmentFromDb(roomServiceModel);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }
            var roomFromDb = await context.Rooms.SingleOrDefaultAsync(x => x.Name == roomServiceModel.Name);

            if (roomFromDb != null)
            {
                roomFromDb.Name = roomServiceModel.Name;
                
                roomFromDb.IsDeleted = false;
                roomFromDb.DeletedOn = null;
                roomFromDb.RoomType = roomTypeFromDb;
                roomFromDb.Department = departmentFromDb;

                context.Rooms.Update(roomFromDb);
                int result = await context.SaveChangesAsync();

                return result > 0;
            }
            else
            {
                Room room = AutoMapper.Mapper.Map<Room>(roomServiceModel);
                room.RoomType = roomTypeFromDb;
                room.Department = departmentFromDb;

                context.Rooms.Add(room);
                int result = await context.SaveChangesAsync();

                return result > 0;
            }
        }

        public IQueryable<RoomServiceModel> GetAllRooms()
        {
            return context.Rooms.Where(room=>room.IsDeleted == false).To<RoomServiceModel>();
        }

        public async Task<RoomServiceModel> GetById(string id)
        {
            return await context.Rooms
                .To<RoomServiceModel>()
                .SingleOrDefaultAsync(room => room.Id == id);
        }

        public async Task<bool> Edit(string id, RoomServiceModel roomServiceModel)
        {
            RoomType roomTypeFromDb = await GetRoomTypeFromDb(roomServiceModel);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            Department departmentFromDb = await GetDepartmentFromDb(roomServiceModel);

            if (departmentFromDb == null)
            {
                throw new ArgumentNullException(nameof(departmentFromDb));
            }

            Room roomFromDb = await context.Rooms.SingleOrDefaultAsync(room => room.Id == id);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            roomFromDb.Name = roomServiceModel.Name;
            roomFromDb.RoomType = roomTypeFromDb;
            roomFromDb.Department = departmentFromDb;


            context.Rooms.Update(roomFromDb);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }


        public async Task<bool> Delete(string id)
        {
            Room roomFromDb = await context.Rooms.SingleOrDefaultAsync(room => room.Id == id);

            if (roomFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomFromDb));
            }

            roomFromDb.IsDeleted = true;
            roomFromDb.DeletedOn = DateTime.UtcNow;

            context.Rooms.Update(roomFromDb);

            int result = await context.SaveChangesAsync();

            return result > 0;

        }

        private Task<RoomType> GetRoomTypeFromDb(RoomServiceModel roomServiceModel)
        {
            return context.RoomTypes
                 .SingleOrDefaultAsync(roomType => roomType.Name == roomServiceModel.RoomType.Name);
        }
        private Task<Department> GetDepartmentFromDb(RoomServiceModel roomServiceModel)
        {
            return context.Departments
                .SingleOrDefaultAsync(department => department.Name == roomServiceModel.Department.Name);
        }
    }
}
