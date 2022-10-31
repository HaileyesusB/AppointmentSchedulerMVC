using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerMVC.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = " Confirm Password")]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password do not Match")]
        public string ConfirmPassword { get; set; } 
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
