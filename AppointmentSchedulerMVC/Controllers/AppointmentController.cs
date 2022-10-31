using AppointmentSchedulerMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerMVC.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            ViewBag.DoctorsList = _appointmentService.GetDoctorList();
            return View();
        }
    }
}
