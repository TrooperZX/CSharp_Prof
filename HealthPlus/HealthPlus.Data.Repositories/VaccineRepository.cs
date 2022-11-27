using HealthPlus.DataBase;
using HealthPlus.DataBase.Entities;
using HealthPlus.Data.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlus.Data.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly HealthPlusContext _database;
        public VaccineRepository(HealthPlusContext database)
        {
            _database = database;
        }
        public async Task CreateVaccineAsync(Vaccine vaccine)
        {
            await _database.Vaccines.AddAsync(vaccine);
        }
               
        public async Task<Vaccine?> GetVaccineByIdAsync(Guid id)
        {
            return await _database
              .Vaccines.FirstOrDefaultAsync(vaccine => vaccine.Id.Equals(id));
        }
               
        public async Task<List<Vaccine?>> GetAllVaccinesAsync()
        {
            return await _database.Vaccines.ToListAsync();
        }
               
        public async Task PatchVaccineAsync(Guid id, Vaccine vaccine)
        {
            var entity = await _database.Vaccines.FirstOrDefaultAsync(v => v.Id.Equals(id));

            if (entity != null)
            {
                entity = vaccine;
            }
        }
               
        public async Task RemoveVaccineAsync(Vaccine vaccine)
        {
             _database.Vaccines.Remove(vaccine);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
