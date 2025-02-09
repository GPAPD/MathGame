using System.ComponentModel.DataAnnotations;

namespace MathGame.Models
{
    /// <summary>
    /// This class represents the user login request model
    /// </summary>
    public class LogInRequestModel
    {
        /// <summary>
        /// Gets or sets the Email of the User.
        /// </summary>
        /// <remarks>
        /// The email should be a valid one according to the regex.
        /// </remarks>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password of the User.
        /// </summary>
        /// <remarks>
        /// The password should be valid according to the .net identity freamwork.
        /// </remarks>
        [Required]
        public string Password { get; set; }


    }
}
