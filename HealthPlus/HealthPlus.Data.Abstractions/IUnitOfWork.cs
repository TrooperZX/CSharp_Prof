using HealthPlus.DataBase.Entities;
using HealthPlus.Data.Abstractions.Repositories;


namespace HealthPlus.Data.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<UserRole> UserRoles { get; }
        IRepository<DocAppointment> DocAppointments { get; }
        IRepository<Medication> Medications { get; }
        IRepository<Prescription> Prescriptions { get; }
        IRepository<Vaccine> Vaccines { get; }
        IRepository<Vaccination> Vaccinations { get; }

        Task<int> Commit();
    }
}
