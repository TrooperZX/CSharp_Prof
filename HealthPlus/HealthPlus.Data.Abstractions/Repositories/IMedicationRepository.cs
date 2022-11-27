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
    public interface IMedicationRepository
    {

        public Task CreateMedicationAsync(Medication medication);

        public Task<Medication?> GetMedicationByIdAsync(Guid id);

        public Task<List<Medication?>> GetAllMedicationsAsync();

        public Task PatchMedicationAsync(Guid id, Medication medication);

        public Task RemoveMedicationAsync(Medication medication);
    }
}
