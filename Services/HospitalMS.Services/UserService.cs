namespace HospitalMS.Services
{
    using System.Threading.Tasks;
    using HospitalMS.Data;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using Microsoft.AspNetCore.Identity;
    using System;

    public class UserService : IUserService
    {
        private readonly HospitalMSDbContext context;
        private readonly UserManager<HospitalMSUser> userManager;

        public UserService(HospitalMSDbContext context, UserManager<HospitalMSUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<HospitalMSUserServiceModel> GetById(string id)
        {
            return (await userManager.FindByIdAsync(id)).To<HospitalMSUserServiceModel>();
        }
    }
}
