using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlus.Core.DataTransferObjects
{
    public class PrescriptionDto
    {
        public Guid Id { get; set; }
        public Guid MedicationId { get; set; }
        public Guid UserId { get; set; }
        public string Dosage { get; set; }
        public DateTime DateOfPrescription { get; set; }
        public DateTime DurationOfPrescription { get; set; }
        public string? Note { get; set; }
    }
}
