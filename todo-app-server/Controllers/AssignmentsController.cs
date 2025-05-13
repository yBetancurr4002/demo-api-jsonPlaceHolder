using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_app_server.Data;
using todo_app_server.DTOs;
using todo_app_server.Models;

namespace todo_app_server.Controllers
{
  [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public AssignmentsController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignments()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            var assignments = await _context.Assignments
                .Where(a => a.UserId == userId)
                .Select(a => new AssignmentDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Status = a.Status
                })
                .ToListAsync();
                
            return assignments;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDto>> GetAssignment(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            var assignment = await _context.Assignments
                .Where(a => a.Id == id && a.UserId == userId)
                .Select(a => new AssignmentDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Status = a.Status
                })
                .FirstOrDefaultAsync();
                
            if (assignment == null)
            {
                return NotFound();
            }
            
            return assignment;
        }
        
        [HttpPost]
        public async Task<ActionResult<AssignmentDto>> CreateAssignment(CreateAssignmentDto createAssignmentDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            var assignment = new Assignment
            {
                Name = createAssignmentDto.Name,
                Description = createAssignmentDto.Description,
                Status = createAssignmentDto.Status,
                UserId = userId
            };
            
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetAssignment), new { id = assignment.Id }, new AssignmentDto
            {
                Id = assignment.Id,
                Name = assignment.Name,
                Description = assignment.Description,
                Status = assignment.Status
            });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, UpdateAssignmentDto updateAssignmentDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);
                
            if (assignment == null)
            {
                return NotFound();
            }
            
            assignment.Name = updateAssignmentDto.Name;
            assignment.Description = updateAssignmentDto.Description;
            assignment.Status = updateAssignmentDto.Status;
            
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);
                
            if (assignment == null)
            {
                return NotFound();
            }
            
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}