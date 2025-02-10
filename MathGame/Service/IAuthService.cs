using MathGame.Models;

namespace MathGame.Service
{
    public interface IAuthService
    {
       public Task<string> Register(RegistrationModel model);

       public Task<LogInResponse> Login(LogInRequestModel model);



    }
}
