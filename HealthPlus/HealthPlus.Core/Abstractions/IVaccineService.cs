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
    }
}
