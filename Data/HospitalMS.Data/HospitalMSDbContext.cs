namespace HospitalMS.Data
{
    using HospitalMS.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;


    public class HospitalMSDbContext : IdentityDbContext<HospitalMSUser, IdentityRole, string>
    {
        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Bed> Beds { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Receptionist> Receptionist { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public HospitalMSDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>()
                .HasMany(room => room.Rooms)
                .WithOne(department => department.Department)
                .HasForeignKey(department => department.DepartmentId)
               .OnDelete(DeleteBehavior.Cascade
               );

            builder.Entity<Department>()
                   .HasMany(doctor => doctor.Doctors)
                   .WithOne(department => department.Department)
                   .HasForeignKey(department => department.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade
           );

            builder.Entity<Department>()
                   .HasMany(patient => patient.Patients)
                   .WithOne(department => department.Department)
                   .HasForeignKey(department => department.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade
           );

            builder.Entity<Bed>()
                .HasOne(patient => patient.Patient)
                .WithOne(bed => bed.Bed)
                .HasForeignKey<Bed>(bed => bed.PatientId);


            base.OnModelCreating(builder);
        }
    }
}
