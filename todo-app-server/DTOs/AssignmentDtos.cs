using System.ComponentModel.DataAnnotations;
using todo_app_server.enums;

namespace todo_app_server.DTOs
{
   public class AssignmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AssignmentStatus Status { get; set; }
    }
    
    public class CreateAssignmentDto
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public AssignmentStatus Status { get; set; }
    }
    
    public class UpdateAssignmentDto
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public AssignmentStatus Status { get; set; }
    }
}