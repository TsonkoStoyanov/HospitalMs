namespace HospitalMS.Services
{
    using System.Threading.Tasks;
    using HospitalMS.Data;
    using HospitalMS.Services.Models;
    using HospitalMS.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using HospitalMS.Data.Models;
    using System;
    using System.Linq;

    public class BedService : IBedService
    {
        private readonly HospitalMSDbContext context;

        public BedService(HospitalMSDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(string roomId, BedServiceModel bedServiceModel)
        {
            Room roomFromDb = await context.Rooms.SingleOrDefaultAsync(room => room.Id == roomId);

            if (roomFromDb == null)
            {
                throw new ArgumentNullException(nameof(roomFromDb));
            }

            if (roomFromDb.Beds.Where(bed=>bed.IsDeleted == false).Count() == 0)
            {
                throw new ArgumentNullException(nameof(roomFromDb));
            }

            Bed bedFromDb = await context.Beds.FirstOrDefaultAsync(bed => bed.Number == bedServiceModel.Number);

            if (bedFromDb != null && bedFromDb.IsDeleted == true)
            {
            
                bedFromDb.Number = bedServiceModel.Number;

                bedFromDb.IsDeleted = false;
                bedFromDb.DeletedOn = null;

                bedFromDb.Room = roomFromDb;

                context.Beds.Update(bedFromDb);

                int result = await context.SaveChangesAsync();

                return result > 0;
            }
            else
            {
                Bed bed = AutoMapper.Mapper.Map<Bed>(bedServiceModel);

                bed.Room = roomFromDb;

                context.Beds.Add(bed);

                int result = await context.SaveChangesAsync();

                return result > 0;
            }

        }

        public async Task<bool> Remove(string roomId)
        {
            Room roomFromDb = await context.Rooms.SingleOrDefaultAsync(room => room.Id == roomId);

            Bed bedFromDb = roomFromDb.Beds.ToList().Last();

            bedFromDb.IsDeleted = true;
            bedFromDb.DeletedOn = DateTime.UtcNow;

            context.Beds.Update(bedFromDb);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(int id, BedServiceModel bedServiceModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BedServiceModel> GetById(int id)
        {
            return await context.Beds
                .To<BedServiceModel>()
                .SingleOrDefaultAsync(bed => bed.Id == id);
        }
    }
}
