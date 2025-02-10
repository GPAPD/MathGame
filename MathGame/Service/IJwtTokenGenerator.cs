using MathGame.Entity;

namespace MathGame.Service
{
    public interface IJwtTokenGenerator
    {
        string GenarateToken(ApplicationUser user);
    }
}
