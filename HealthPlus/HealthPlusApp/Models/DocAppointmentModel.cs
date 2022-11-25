using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlusApp.Models
{
    public class DocAppointmentModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Specialization { get; set; }
        public string Note { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
    }
}
