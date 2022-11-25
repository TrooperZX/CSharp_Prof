using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthPlus.Core.DataTransferObjects;

namespace HealthPlus.Core.Abstractions
{
    public interface IPrescriptionService
    {
        Task<int> CreatePrescriptionAsync(PrescriptionDto dto);

        Task<List<PrescriptionDto>> GetPrescriptionByPageNumberAndPageSizeAsync
        (int pageNumber, int pageSize);

        Task<PrescriptionDto> GetPrescriptionByIdAsync(Guid id);

        Task<int> UpdatePrescriptionAsync(Guid id, PrescriptionDto? dto);

        Task DeletePrescriptionAsync(Guid id);
    }
}
