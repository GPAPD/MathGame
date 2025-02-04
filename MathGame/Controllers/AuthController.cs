using Microsoft.AspNetCore.Mvc;
using MathGame.Models;

namespace MathGame.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            LogInRequestModel model = new LogInRequestModel(); 

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LogInRequestModel request) 
        {

        
            return View(request);
        }

        [HttpGet]
        public IActionResult Register() 
        {
            RegistrationModel model = new RegistrationModel();
        
            return View(model);
        }
    }
}
