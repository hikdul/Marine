using System.ComponentModel.DataAnnotations;

namespace Marine.Auth
{
    /// <summary>
    /// para logearnos
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// contraseña
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
