using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlus.Core.DataTransferObjects
{
    public class VaccinationDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateOfVaccination { get; set; }
        public string Status { get; set; }
        public string? Note { get; set; }
        public Guid VaccineId { get; set; }

    }
}
