using System.ComponentModel.DataAnnotations;
using todo_app_server.enums;

namespace todo_app_server.Models
{
      public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }

        public UserRole Role { get; set; } = UserRole.User;

        
        public List<Assignment> Assignments { get; set; }
    }
}