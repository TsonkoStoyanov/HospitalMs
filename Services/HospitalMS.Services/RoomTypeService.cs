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
            var roomTypeFromDb = await context.RoomTypes.SingleOrDefaultAsync(x => x.Name == roomTypeServiceModel.Name);

            if (roomTypeFromDb != null)
            {
                roomTypeFromDb.Name = roomTypeServiceModel.Name;
                roomTypeFromDb.PriceForBed = roomTypeServiceModel.PriceForBed;
                roomTypeFromDb.IsDeleted = false;
                roomTypeFromDb.DeletedOn = null; 

                context.RoomTypes.Update(roomTypeFromDb);
                int result = await context.SaveChangesAsync();

                return result > 0;
            }
            else
            {

                RoomType roomType = AutoMapper.Mapper.Map<RoomType>(roomTypeServiceModel);

                context.RoomTypes.Add(roomType);
                int result = await context.SaveChangesAsync();

                return result > 0;
            }
        }

        public IQueryable<RoomTypeServiceModel> GetAllRoomTypes()
        {
            return context.RoomTypes.Where(roomType => roomType.IsDeleted == false).To<RoomTypeServiceModel>();
        }

        public async Task<RoomTypeServiceModel> GetById(int id)
        {
            return await context.RoomTypes
                .To<RoomTypeServiceModel>()
                .SingleOrDefaultAsync(roomType => roomType.Id == id);
        }

        public async Task<bool> Edit(int id, RoomTypeServiceModel roomTypeServiceModel)
        {
            RoomType roomTypeFromDb = await context.RoomTypes.SingleOrDefaultAsync(roomType => roomType.Id == id);

            if (roomTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomTypeFromDb));
            }

            roomTypeFromDb.Name = roomTypeServiceModel.Name;
            roomTypeFromDb.PriceForBed = roomTypeServiceModel.PriceForBed;

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

            roomTypeFromDb.IsDeleted = true;
            roomTypeFromDb.DeletedOn = DateTime.UtcNow;

            context.RoomTypes.Update(roomTypeFromDb);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }



    }
}
