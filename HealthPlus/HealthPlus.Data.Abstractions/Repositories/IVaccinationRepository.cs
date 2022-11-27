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
    public interface IVaccinationRepository
    {
        public Task CreateVaccinationAsync(Vaccination vaccination);

        public Task<Vaccination?> GetVaccinationByIdAsync(Guid id);

        public Task<List<Vaccination?>> GetAllVaccinationsByUserIdAsync(Guid id);

        public Task PatchVaccinationAsync(Guid id, Vaccination vaccination);

        public Task RemoveVaccinationAsync(Vaccination vaccination);

    }   
}
