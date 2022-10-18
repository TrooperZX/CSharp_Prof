using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlus.DataBase.Entities
{
    public class DocAppointment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Specialization { get; set; }
        public string? Note { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}

