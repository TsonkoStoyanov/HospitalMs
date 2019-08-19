using HospitalMS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalMS.Data
{
    public class HospitalMSDbContext : IdentityDbContext<HospitalMSUser, IdentityRole, string>
    {
        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Departament> Departaments { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Bed> Beds { get; set; }

        public HospitalMSDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
