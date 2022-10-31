using AppointmentSchedulerMVC.Models.ViewModels;

namespace AppointmentSchedulerMVC.Services
{
    public interface IAppointmentService
    {
        public List<DoctorViewModel> GetDoctorList();

        public List<PatientViewModel> GetPatientList();
    }
}
