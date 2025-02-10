using Microsoft.AspNetCore.Mvc;
using MathGame.Models;
using MathGame.Service;

namespace MathGame.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            LogInRequestModel model = new LogInRequestModel(); 

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LogInRequestModel request) 
        {
            var result = _authService.Login(request);

            if (request == null) 
            {

            }
        
            return View(request);
        }

        [HttpGet]
        public IActionResult Register() 
        {
            RegistrationModel model = new RegistrationModel();
       
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationModel model) 
        {
           var result = await _authService.Register(model);

            return View(model);
        }
    }
}
