using HospitalMS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalMS.Data
{
    public class HospitalDbContext : IdentityDbContext<HospitalMSUser, IdentityRole, string>
    {
        public DbSet<Hospital> Hospitals { get; set; }

        public HospitalDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
