using CsStatTracker.Data;
using CsStatTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace CsStatTracker.Controllers
{
    public class MembersController : Controller
    {
        private readonly StatsContext _context;
        
        public MembersController(StatsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                Members newMember = new()
                {
                    Email = registerModel.Email,
                    Password = registerModel.Password
                };
                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                LogUserIn(newMember.Email);

                return RedirectToAction("Index", "Home");
            }
            
            return View(registerModel);
        }
        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel) 
        {
            if (ModelState.IsValid)
            {
                Members? m = (from Members in _context.Members
                             where Members.Email == loginModel.Email
                             &&  Members.Password == loginModel.Password
                             select Members).SingleOrDefault();
                if (m != null)
                {
                    LogUserIn(loginModel.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Username or password.");
            }
            return View(loginModel);
        }
        private void LogUserIn(string email)
        {
            HttpContext.Session.SetString("Email", email);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
