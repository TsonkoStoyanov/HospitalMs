namespace HospitalMS.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Data;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Models;
    using HospitalMS.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using HospitalMS.Common;
    using System;
    using Microsoft.EntityFrameworkCore;


    public class ReceptionistService : IReceptionistService
    {
        private readonly HospitalMSDbContext context;
        private readonly UserManager<HospitalMSUser> userManager;

        public ReceptionistService(HospitalMSDbContext context, UserManager<HospitalMSUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<bool> Create(string password, ReceptionistServiceModel receptionistServiceModel)
        {
            var user = new HospitalMSUser { UserName = receptionistServiceModel.Email, Email = receptionistServiceModel.Email };
            var userCreateResult = await userManager.CreateAsync(user, password);

            if (userCreateResult.Succeeded)
            {
                user.EmailConfirmed = true;               

                await userManager.AddToRoleAsync(user, GlobalConstants.ReceptionistRoleName);
            }

            Hospital hospitalFromDb = await GetHospitalFromDb(receptionistServiceModel);

            if (hospitalFromDb == null)
            {
                throw new ArgumentNullException(nameof(hospitalFromDb));
            }

            receptionistServiceModel.HospitalMSUserId = user.Id;

            Receptionist receptionist = AutoMapper.Mapper.Map<Receptionist>(receptionistServiceModel);

            receptionist.Hospital = hospitalFromDb;
            context.Receptionists.Add(receptionist);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            Receptionist receptionistFromDb = await context.Receptionists.SingleOrDefaultAsync(receptionist => receptionist.Id == id);

            if (receptionistFromDb == null)
            {
                throw new ArgumentNullException(nameof(receptionistFromDb));
            }

            var userIdentityId = receptionistFromDb.HospitalMSUserId;

            var user = await userManager.FindByIdAsync(userIdentityId);
            var rolesForUser = await userManager.GetRolesAsync(user);

            using (var transaction = context.Database.BeginTransaction())
            {
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        var resultUser = await userManager.RemoveFromRoleAsync(user, item);
                    }
                }

                await userManager.DeleteAsync(user);
                transaction.Commit();
            }

            context.Receptionists.Remove(receptionistFromDb);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, ReceptionistServiceModel receptionistServiceModel)
        {
            Hospital hospitalFromDb = await GetHospitalFromDb(receptionistServiceModel);

            if (hospitalFromDb == null)
            {
                throw new ArgumentNullException(nameof(hospitalFromDb));
            }

            Receptionist receptionistFromDb = await context.Receptionists.SingleOrDefaultAsync(receptionist => receptionist.Id == id);

            if (receptionistFromDb == null)
            {
                throw new ArgumentNullException(nameof(receptionistFromDb));
            }

            receptionistFromDb.FirstName = receptionistServiceModel.FirstName;
            receptionistFromDb.LastName = receptionistServiceModel.LastName;
            receptionistFromDb.PhoneNumber = receptionistServiceModel.PhoneNumber;
            receptionistFromDb.Hospital = hospitalFromDb;


            context.Receptionists.Update(receptionistFromDb);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<ReceptionistServiceModel> GetAllReceptionists()
        {
            return context.Receptionists.To<ReceptionistServiceModel>();
        }

        public async Task<ReceptionistServiceModel> GetById(string id)
        {
            return await context.Receptionists
                .To<ReceptionistServiceModel>()
                .SingleOrDefaultAsync(receptionist => receptionist.Id == id);
        }

        private Task<Hospital> GetHospitalFromDb(ReceptionistServiceModel receptionistServiceModel)
        {
            return context.Hospitals
                 .SingleOrDefaultAsync(hospital => hospital.Name == receptionistServiceModel.HospitalName);
        }
    }
}
