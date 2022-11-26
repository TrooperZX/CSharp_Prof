using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthPlus.Core.DataTransferObjects;

namespace HealthPlus.Core.Abstractions
{
    public interface IVaccineService
    {
        Task<int> CreateVaccineAsync(VaccineDto dto);

        Task<Guid?> GetVaccineIdByNameAsync(string name);

        Task<VaccineDto> GetVaccineByIdAsync(Guid id);

        Task<int> UpdateVaccineAsync(Guid id, VaccineDto? patchList);

        Task DeleteVaccineById(Guid id);
    }
}
