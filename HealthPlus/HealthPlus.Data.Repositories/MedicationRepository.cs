using HealthPlus.DataBase;
using HealthPlus.DataBase.Entities;
using HealthPlus.Data.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlus.Data.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly HealthPlusContext _database;

        public MedicationRepository(HealthPlusContext database)
        {
            _database = database;
        }

        public async Task CreateMedicationAsync(Medication medication)
        {
            await _database.Meds.AddAsync(medication);
        }

        public async Task<Medication?> GetMedicationByIdAsync(Guid id)
        {
            return await _database
               .Meds.FirstOrDefaultAsync(med => med.Id.Equals(id));
        }

        public async Task<List<Medication?>> GetAllMedicationsAsync()
        {
            return await _database.Meds.ToListAsync();
        }

        public async Task PatchMedicationAsync(Guid id, Medication medication)
        {
            var entity = await _database.Meds.FirstOrDefaultAsync(med => med.Id.Equals(id));

            if (entity != null)
            {
                entity = medication;
            }
        }

        public async Task RemoveMedicationAsync(Medication medication)
        {
            _database.Meds.Remove(medication);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
