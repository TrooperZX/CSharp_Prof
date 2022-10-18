using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlusApp.Models
{
    public class DocAppointmentModel
    {
        [Required]
        public string Specialization { get; set; }
        public string Note { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
