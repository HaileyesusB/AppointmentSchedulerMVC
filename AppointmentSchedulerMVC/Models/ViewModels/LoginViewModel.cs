using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerMVC.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Remenber me?")]
        public bool RememberMe { get; set; }
    }
}
