namespace HospitalMS.Services
{
    using System;
    using System.Threading.Tasks;
    using HospitalMS.Data;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class HospitalService : IHospitalService
    {
        private readonly HospitalMSDbContext context;

        public HospitalService(HospitalMSDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Edit(string id, HospitalServiceModel hospitalServiceModel)
        {
            Hospital hospitalFromDb = await this.context.Hospitals.SingleOrDefaultAsync(hospital => hospital.Id == id);

            if (hospitalFromDb == null)
            {
                throw new ArgumentNullException(nameof(hospitalFromDb));
            }

            hospitalFromDb.Name = hospitalServiceModel.Name;
            hospitalFromDb.Address = hospitalServiceModel.Address;
            hospitalFromDb.Email = hospitalServiceModel.Email;
            hospitalFromDb.PhoneNumber = hospitalServiceModel.PhoneNumber;


            this.context.Hospitals.Update(hospitalFromDb);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<HospitalServiceModel> Get()
        {
            return await this.context.Hospitals
              .To<HospitalServiceModel>()
              .FirstOrDefaultAsync();
        }
    }
}
