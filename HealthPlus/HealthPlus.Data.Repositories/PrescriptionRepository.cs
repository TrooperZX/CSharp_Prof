using HealthPlus.DataBase;
using HealthPlus.DataBase.Entities;
using HealthPlus.Core;
using HealthPlus.Data.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthPlus.Data.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly HealthPlusContext _database;

        public PrescriptionRepository(HealthPlusContext database)
        {
            _database = database;
        }

        public async Task CreatePrescriptionAsync(Prescription prescription)
        {
            await _database.Prescriptions.AddAsync(prescription);
        }
        public async Task<Prescription?> GetPrescriptionByIdAsync(Guid id)
        {
            return await _database
              .Prescriptions.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<List<Prescription?>> GetAllPrescriptionsByUserIdAsync(Guid id)
        {
            return await _database.Prescriptions.Where(p => p.UserId.Equals(id)).ToListAsync();
        }
        public async Task PatchPrescriptionAsync(Guid id, Prescription prescription)
        {
            var entity = await _database.Prescriptions.FirstOrDefaultAsync(p => p.Id.Equals(id));

            if (entity != null)
            {
                entity = prescription;
            }
        }
        public async Task RemovePrescriptionAsync(Prescription prescription)
        {
            _database.Prescriptions.Remove(prescription);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
