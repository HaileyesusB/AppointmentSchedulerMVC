using Microsoft.AspNetCore.Identity;

namespace AppointmentSchedulerMVC.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
    }
}
