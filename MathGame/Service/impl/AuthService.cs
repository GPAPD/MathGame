using MathGame.Domain;
using MathGame.Entity;
using MathGame.Models;
using Microsoft.AspNetCore.Identity;

namespace MathGame.Service.impl
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
                
        public AuthService(AppDbContext db, 
            IJwtTokenGenerator jwtTokenGenerator,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager )
        {
            _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
            //_roleManager = roleManager;
        }

        public async Task<LogInResponse> Login(LogInRequestModel model)
        {
            LogInResponse logInRequestModel = new();

            try
            {
                var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == model.Email.ToLower());
                bool isVal = await _userManager.CheckPasswordAsync(user, model.Password);

                //if login fales 
                if (isVal == false || user == null)
                {
                    return new LogInResponse() { User = null, Token = "" };

                }

                // If user was foun Generate JwtToken
                var jwtToken = _jwtTokenGenerator.GenarateToken(user);

                UserModel valUser = new();

                valUser.Email = user.Email;
                valUser.ID = user.Id;
                valUser.Name = user.Name;
                valUser.PhoneNumber = user.PhoneNumber;

                logInRequestModel.User = valUser;
                logInRequestModel.Token = jwtToken;
                
            }
            catch (Exception ex) 
            {
                return null;
            }

            return logInRequestModel;
        }

        public async Task<string> Register(RegistrationModel model)
        {
            ApplicationUser user = new()
            {
                UserName = model.Email,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
            };
            try
            {
                //createing a user 
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == model.Email);
                    UserModel userModel = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber,
                    };
                    return "";
                }
                else 
                {
                    return result.Errors.FirstOrDefault().Description;
                
                }
            }
            catch (Exception ex) 
            {
            
            }
            return "Error Encounted";
        }
    }
}
