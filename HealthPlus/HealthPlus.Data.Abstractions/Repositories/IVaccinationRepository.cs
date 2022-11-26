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
        //CREATE
        Task AddAsync(Vaccination entity);

        //READ
        Task<Vaccination?> GetVaccinationByIdAsync(Guid id);
        Task<List<Vaccination?>> GetAllAsync();
        IQueryable<Vaccination> FindBy(Expression<Func<Vaccination, bool>> searchExpression,
    params Expression<Func<Vaccination, object>>[] includes);

        //UPDATE
        void Update(Vaccination entity);
        Task PatchAsync(Guid id, List<PatchModel> patchData);

        //DELETE
        void Remove(Vaccination entity);
    }
}
