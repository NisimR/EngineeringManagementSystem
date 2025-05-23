using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Models;
using EngineeringManagementSystem.API.Requests;
using EngineeringManagementSystem.API.DTOs;
using Microsoft.AspNetCore.Identity;


namespace EngineeringManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EngineeringManegementDbContext _context;

        public UsersController(EngineeringManegementDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }




        //מקבלת סיסמא ועושה האשינג
        private string HashPassword(string plainPassword)
        {
            var hasher = new PasswordHasher<object>();
            return hasher.HashPassword(null, plainPassword);
        }
        //הוספת יוזר חדש
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser([FromBody] UserRequest request)
        {

            
            string hashedPassword = HashPassword(request.Password);

            var user = new User
            {
                Username = request.UserName,
                FullName = request.FullName,
                PasswordHash = hashedPassword,
                Role = request.Role,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var dto = new UserDTO
            {
                UserId = user.UserId,
                UserName = user.Username,
                FullName = user.FullName,
                Role = user.Role,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserRequest request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            user.Username = request.UserName;
            user.FullName = request.FullName;
            user.Role = request.Role;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;

            if (!string.IsNullOrEmpty(request.Password))
            {
                user.PasswordHash = HashPassword(request.Password);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
