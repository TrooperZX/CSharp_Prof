using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlus.DataBase.Entities
{
    public class Prescription : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid MedicationId { get; set; }
        public Guid UserId { get; set; }
        public string Dosage { get; set; }
        public DateTime DateOfPrescription { get; set; }
        public DateTime DurationOfPrescription { get; set; }
        public string? Note { get; set; }
        public virtual Medication Medication { get; set; }
    }
}
