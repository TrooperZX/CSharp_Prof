using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlusApp.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Remote("CheckEmail", "Account",
        HttpMethod = WebRequestMethods.Http.Post, ErrorMessage = "Email is already occupied")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
    }
}
