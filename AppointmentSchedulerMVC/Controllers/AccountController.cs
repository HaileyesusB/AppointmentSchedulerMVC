using AppointmentSchedulerMVC.HelperUtility;
using AppointmentSchedulerMVC.Models;
using AppointmentSchedulerMVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        UserManager<ApplicationUser> _userManager;

        SignInManager<ApplicationUser> _signInManager;

        RoleManager<IdentityRole> _roleManager;
        public AccountController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager; 
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Appointment");
                }
                ModelState.AddModelError("", "Invalid login Attempt");
            }
            return View(loginModel);
        }

        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Patient));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Doctor));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded) 
                {
                    await _userManager.AddToRoleAsync(user,  model.RoleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var errot in result.Errors)
                {
                  ModelState.AddModelError("", errot.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogOff() 
        {
          await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn", "Account");
        }
    }
}
