using Microsoft.AspNetCore.Mvc;
using MathGame.Models;

namespace MathGame.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            LogInRequestModel model = new LogInRequestModel(); 

            return View("Login",model);
        }
    }
}
