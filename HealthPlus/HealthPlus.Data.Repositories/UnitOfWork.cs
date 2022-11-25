using HealthPlus.DataBase;
using HealthPlus.DataBase.Entities;
using HealthPlus.Data.Abstractions;
using HealthPlus.Data.Abstractions.Repositories;

namespace HealthPlus.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthPlusContext _database;
        public IRepository<User> Users { get; }
        public IRepository<UserRole> UserRoles { get; }
        public IRepository<DocAppointment> DocAppointments { get; }
        public IRepository<Medication> Medications { get; }
        public IRepository<Prescription> Prescriptions { get; }
        public IRepository<Vaccine> Vaccines { get; }
        public IRepository<Vaccination> Vaccinations { get; }

        public UnitOfWork(HealthPlusContext database, 
            IRepository<User> users,
            IRepository<UserRole> userRoles,
            IRepository<DocAppointment> docAppointments,
            IRepository<Medication> medications,
            IRepository<Prescription> prescriptions,
            IRepository<Vaccine> vaccines,
            IRepository<Vaccination> vaccinations)
        {
            _database = database;
            Users = users;
            UserRoles = userRoles;
            DocAppointments = docAppointments;
            Medications = medications;
            Prescriptions = prescriptions;
            Vaccines = vaccines;
            Vaccinations = vaccinations;
        }
        public async Task<int> Commit()
        {
            return await _database.SaveChangesAsync();
        }
    }
}