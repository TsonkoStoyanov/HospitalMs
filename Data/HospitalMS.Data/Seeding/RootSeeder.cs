namespace HospitalMS.Data.Seeding
{
    using HospitalMS.Common.HospitalMS.Common;
    using HospitalMS.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class RootSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalMSDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<HospitalMSUser>>();

            if (!userManager.Users.Any())
            {
                var user = new HospitalMSUser
                {
                    UserName = GlobalConstants.AdminEmail,
                    Email = GlobalConstants.AdminEmail,
                    EmailConfirmed = true,
                };

                var password = "superSecret";

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }

            }
        }
    }
}
