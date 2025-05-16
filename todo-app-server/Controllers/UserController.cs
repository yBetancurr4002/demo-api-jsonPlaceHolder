using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_app_server.Data;
using todo_app_server.DTOs;
using todo_app_server.enums;
using todo_app_server.Models;

namespace todo_app_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = nameof(UserRole.Admin))] // Solo Admin puede acceder
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role.ToString()
                })
                .ToListAsync();

            return Ok(users);
        }
    }
}
