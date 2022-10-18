using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlus.DataBase.Entities
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid RoleId { get; set; }
        public UserRole Role { get; set; }
        public List<DocAppointment> DocAppointments { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
        public List<Prescription> Prescriptions { get; set; }
    }
}
