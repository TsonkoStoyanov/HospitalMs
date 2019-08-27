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


    public class RoomTypeService : IRoomTypeService
    {
        private readonly HospitalMSDbContext context;

        public RoomTypeService(HospitalMSDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> CreateRoomType(RoomTypeServiceModel roomTypeServiceModel)
        {
            RoomType roomType = AutoMapper.Mapper.Map<RoomType>(roomTypeServiceModel);

            context.RoomTypes.Add(roomType);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<RoomTypeServiceModel> GetAllRoomTypes()
        {
            return context.RoomTypes.To<RoomTypeServiceModel>();
        }

        public async Task<RoomTypeServiceModel> GetById(int id)
        {
            return await context.RoomTypes
                .To<RoomTypeServiceModel>()
                .SingleOrDefaultAsync(roomType => roomType.Id == id);
        }

        public async Task<bool> Edit(int id, RoomTypeServiceModel roomtypeServiceModel)
        {
            RoomType roomTypeFromDb = await context.RoomTypes.SingleOrDefaultAsync(roomType => roomType.Id == id);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            roomTypeFromDb.Name = roomtypeServiceModel.Name;

            context.RoomTypes.Update(roomTypeFromDb);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            RoomType roomTypeFromDb = await context.RoomTypes.SingleOrDefaultAsync(roomType => roomType.Id == id);

            
            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            context.RoomTypes.Remove(roomTypeFromDb);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

    

    }
}
