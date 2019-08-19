namespace HospitalMS.Data.Seeding
{
    using HospitalMS.Common;
    using HospitalMS.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class HospitalSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalMSDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (!dbContext.Hospitals.Any())
            {
                var hospital = new Hospital
                {
                    Name = GlobalConstants.HospitalName,
                    Address =GlobalConstants.HospitalAddress,
                    Email = GlobalConstants.HospitalEmail,
                    PhoneNumber = GlobalConstants.HospitalPhone,
                };

                await dbContext.Hospitals.AddAsync(hospital);
                await dbContext.SaveChangesAsync();
            }

            
        }
    }
}