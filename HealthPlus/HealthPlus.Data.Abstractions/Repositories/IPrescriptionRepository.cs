using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthPlus.DataBase.Entities;
using HealthPlus.Core;
using System.Linq.Expressions;

namespace HealthPlus.Data.Abstractions.Repositories
{
    public interface IPrescriptionRepository
    {
        public Task CreatePrescriptionAsync(Prescription prescription);

        public Task<Prescription?> GetPrescriptionByIdAsync(Guid id);

        public Task<List<Prescription?>> GetAllPrescriptionsByUserIdAsync(Guid id);

        public Task PatchPrescriptionAsync(Guid id, Prescription prescription);

        public Task RemovePrescriptionAsync(Prescription prescription);
    }
}
