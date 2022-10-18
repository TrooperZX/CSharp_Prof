using System.ComponentModel.DataAnnotations;

namespace HealthPlusApp.Models
{
    public class VaccineModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
