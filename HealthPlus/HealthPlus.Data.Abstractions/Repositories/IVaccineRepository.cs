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
    public interface IVaccineRepository
    {
        public Task CreateVaccineAsync(Vaccine vaccine);

        public Task<Vaccine?> GetVaccineByIdAsync(Guid id);

        public Task<List<Vaccine?>> GetAllVaccinesAsync();

        public Task PatchVaccineAsync(Guid id, Vaccine vaccine);

        public Task RemoveVaccineAsync(Vaccine vaccine);
    }
}
