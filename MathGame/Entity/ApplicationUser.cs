using Microsoft.AspNetCore.Identity;

namespace MathGame.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

    }
}
