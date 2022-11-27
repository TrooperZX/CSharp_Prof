using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthPlus.Core.DataTransferObjects;

namespace HealthPlus.Core.Abstractions
{
    public interface IVaccinationService
    {
        Task<int> CreateVaccinationAsync(VaccinationDto dto);

        Task<Guid?> GetVaccinationIdByDateAndVaccineIdAsync(DateTime vaccinationDate, Guid vaccineId);

        Task<VaccinationDto> GetVaccinationByIdAsync(Guid id);

        Task<int> UpdateVaccinationAsync(Guid id, VaccinationDto? patchList);

        Task DeleteVaccinationById(Guid id);
    }
}
//public Guid Id { get; set; }
//public Guid UserId { get; set; }
//public DateTime DateOfVaccination { get; set; }
//public string Status { get; set; }
//public string? Note { get; set; }
