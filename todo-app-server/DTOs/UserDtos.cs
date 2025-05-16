using System.ComponentModel.DataAnnotations;

namespace todo_app_server.DTOs
{
   public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
    
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
    
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } 
        public string Token { get; set; } // Opcional, si devuelves token en login
    }
}