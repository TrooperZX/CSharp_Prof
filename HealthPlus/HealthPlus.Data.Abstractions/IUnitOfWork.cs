using HealthPlus.DataBase.Entities;
using HealthPlus.Data.Abstractions.Repositories;


namespace HealthPlus.Data.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<UserRole> UserRoles { get; }
        Task<int> Commit();
    }
}
