namespace HospitalMS.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(HospitalMSDbContext dbContext, IServiceProvider serviceProvider);
    }
}
