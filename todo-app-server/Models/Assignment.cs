
using System.ComponentModel.DataAnnotations;
using todo_app_server.enums;

namespace todo_app_server.Models
{
  public class Assignment
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public AssignmentStatus Status { get; set; }
        
        public int UserId { get; set; }
        
        public User User { get; set; }
    }
}