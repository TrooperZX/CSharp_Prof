using HealthPlus.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthPlus.DataBase
{
    public class HealthPlusContext : DbContext
    {
        public DbSet<DocAppointment> DocAppointments { get; set; }
        public DbSet<Medication> Meds { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public HealthPlusContext(DbContextOptions<HealthPlusContext> options) 
            : base(options)
        {
        }
    }
}