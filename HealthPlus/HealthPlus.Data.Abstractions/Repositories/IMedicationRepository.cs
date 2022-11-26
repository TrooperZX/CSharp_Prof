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
        //CREATE
        Task AddAsync(Medication entity);

        //READ
        Task<Medication?> GetMedicationByIdAsync(Guid id);
        Task<List<Medication?>> GetAllAsync();
        IQueryable<Medication> FindBy(Expression<Func<Medication, bool>> searchExpression,
    params Expression<Func<Medication, object>>[] includes);

        //UPDATE
        void Update (Medication entity);
        Task PatchAsync (Guid id, List<PatchModel> patchData);

        //DELETE
        void Remove(Medication entity);
    }
}
