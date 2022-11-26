namespace HealthPlusApp.Models
{
    public class RegisterUserRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
