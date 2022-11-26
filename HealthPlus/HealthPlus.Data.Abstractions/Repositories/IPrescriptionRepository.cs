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
        //CREATE
        Task AddAsync(Prescription entity);

        //READ
        Task<Prescription?> GetPrescriptionByIdAsync(Guid id);
        Task<List<Prescription?>> GetAllAsync();
        IQueryable<Prescription> FindBy(Expression<Func<Prescription, bool>> searchExpression,
    params Expression<Func<Prescription, object>>[] includes);

        //UPDATE
        void Update(Prescription entity);
        Task PatchAsync(Guid id, List<PatchModel> patchData);

        //DELETE
        void Remove(Prescription entity);
    }
}
