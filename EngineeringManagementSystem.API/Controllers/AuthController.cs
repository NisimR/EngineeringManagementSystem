using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Models;
//using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly EngineeringManegementDbContext _context;

        public AuthController(EngineeringManegementDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("יש להזין שם משתמש וסיסמה");

            var user = _context.Users.FirstOrDefault(u =>
                u.Username == request.Username && u.PasswordHash == request.Password);

            if (user == null)
                return Unauthorized("שם משתמש או סיסמה שגויים");

            var userDto = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                Role = user.Role
            };

            return Ok(userDto);
        }
    }
}
