using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthPlus.Core.DataTransferObjects;

namespace HealthPlus.Core.Abstractions
{
    public interface IMedicationService
    {
        Task<int> CreateMedicationAsync(MedicationDto dto);

        Task<List<MedicationDto>> GetMedicationByPageNumberAndPageSizeAsync
        (int pageNumber,int pageSize);

        Task<MedicationDto> GetMedicationByIdAsync(Guid id);

        Task<int> UpdateMedicationAsync(Guid id, MedicationDto? dto);

        Task DeleteMedicationAsync(Guid id);

    }
}
