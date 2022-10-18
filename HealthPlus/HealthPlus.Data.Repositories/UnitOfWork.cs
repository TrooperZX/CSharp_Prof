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

        public UnitOfWork(HealthPlusContext database, 
            IRepository<User> users, 
            IRepository<UserRole> userRoles)
        {
            _database = database;
            Users = users;
            UserRoles = userRoles;
        }
        public async Task<int> Commit()
        {
            return await _database.SaveChangesAsync();
        }
    }
}