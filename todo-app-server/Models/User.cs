using System.ComponentModel.DataAnnotations;

namespace todo_app_server.Models
{
      public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        
        public List<Assignment> Assignments { get; set; }
    }
}