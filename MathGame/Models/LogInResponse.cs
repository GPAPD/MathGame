namespace MathGame.Models
{
    /// <summary>
    /// This class represents the user login response model
    /// </summary>
    public class LogInResponse
    {
        /// <summary>
        /// Gets or sets the JWT Token of the User.
        /// </summary>
        public UserModel User { get; set; }

        /// <summary>
        /// Gets or sets the JWT Token of the User.
        /// </summary>
        public string Token { get; set; }
    }
}
