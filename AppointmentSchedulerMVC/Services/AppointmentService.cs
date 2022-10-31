using AppointmentSchedulerMVC.HelperUtility;
using AppointmentSchedulerMVC.Models;
using AppointmentSchedulerMVC.Models.ViewModels;

namespace AppointmentSchedulerMVC.Services
{
    
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _dbContext;

        public AppointmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<DoctorViewModel> GetDoctorList()
        {
            var doctors = (from user in _dbContext.Users
                           join userRoles in _dbContext.UserRoles on user.Id equals userRoles.UserId
                           join roles in _dbContext.Roles.Where(x=> x.Name == Helper.Doctor) on userRoles.RoleId equals roles.Id
                           select new DoctorViewModel
                           {
                               Id = user.Id,
                               Name = user.Name,
                           }).ToList();

            return doctors;
        }

        public List<PatientViewModel> GetPatientList()
        {
            var patient = (from user in _dbContext.Users
                           join userRoles in _dbContext.UserRoles on user.Id equals userRoles.UserId
                           join roles in _dbContext.Roles.Where(x => x.Name == Helper.Patient) on userRoles.RoleId equals roles.Id
                           //Projection
                           select new PatientViewModel
                           {
                               Id = user.Id,
                               Name = user.Name,
                           }).ToList();

            return patient;
        }
    }
}
