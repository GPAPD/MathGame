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
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager )
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<LogInRequestModel> Login(LogInRequestModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> Register(RegistrationModel model)
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
                    return userModel;
                }
            }
            catch (Exception ex) 
            {
            
            }
            return new UserModel();
        }
    }
}
