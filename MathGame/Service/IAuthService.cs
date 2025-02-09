using MathGame.Models;

namespace MathGame.Service
{
    public interface IAuthService
    {
        Task<UserModel> Register(RegistrationModel model);

        Task<LogInRequestModel> Login(LogInRequestModel model);



    }
}
