using HospitalMS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalMS.Data
{
    public class HospitalDbContext : IdentityDbContext<HospitalMSUser, HospitalMSRole, string>
    {
        public DbSet<Hospital> Hospitals { get; set; }

        public HospitalDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
