using HealthPlus.DataBase;
using HealthPlus.DataBase.Entities;
using HealthPlus.Data.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlus.Data.Repositories
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly HealthPlusContext _database;
        public VaccinationRepository(HealthPlusContext database)
        {
            _database = database;
        }
        public async Task CreateVaccinationAsync(Vaccination vaccination)
        {
            await _database.Vaccinations.AddAsync(vaccination);
        }

        public async Task<Vaccination?> GetVaccinationByIdAsync(Guid id)
        {
            return await _database
              .Vaccinations.FirstOrDefaultAsync(vaccination => vaccination.Id.Equals(id));
        }

        
        public async Task<List<Vaccination?>> GetAllVaccinationsByUserIdAsync(Guid id)
        {
            return await _database.Vaccinations.Where(v => v.UserId.Equals(id)).ToListAsync();
        }

        public async Task PatchVaccinationAsync(Guid id, Vaccination vaccination)
        {
            var entity = await _database.Vaccinations.FirstOrDefaultAsync(v => v.Id.Equals(id));

            if (entity != null)
            {
                entity = vaccination;
            }
        }

        public async Task RemoveVaccinationAsync(Vaccination vaccination)
        {
            _database.Vaccinations.Remove(vaccination);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
