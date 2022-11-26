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
        //CREATE
        Task AddAsync(Vaccine entity);

        //READ
        Task<Vaccine?> GetVaccineByIdAsync(Guid id);
        Task<List<Vaccine?>> GetAllAsync();
        IQueryable<Vaccine> FindBy(Expression<Func<Vaccine, bool>> searchExpression,
    params Expression<Func<Vaccine, object>>[] includes);

        //UPDATE
        void Update(Vaccine entity);
        Task PatchAsync(Guid id, List<PatchModel> patchData);

        //DELETE
        void Remove(Vaccine entity);
    }
}
