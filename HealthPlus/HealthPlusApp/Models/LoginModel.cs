using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlusApp.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Remote("CheckEmail", "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
