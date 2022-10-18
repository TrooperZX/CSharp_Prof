using System.ComponentModel.DataAnnotations;

namespace HealthPlusApp.Models
{
    public class UserRoleModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
