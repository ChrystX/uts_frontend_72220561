using System.ComponentModel.DataAnnotations;

namespace uts_frontend_72220561.Models
{
    public class User
    {
        public User()
        {
            Email = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            FullName = string.Empty;
        }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }
    }

    public class LoginUser
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }

    public class Role
    {
        [Required]
        public string Name { get; set; }
    }

    public class UserRole
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string RoleName { get; set; }
    }

}
