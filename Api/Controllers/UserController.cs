using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;
using Api.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Userlogin login)
        {
            //var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == login.Username);
            var user = await _context.Users.SingleOrDefaultAsync(u =>
            u.Username == login.Username || u.Email == login.Username);
            if (user == null)
            {
                return Unauthorized();
            }
            
            if (!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                return Unauthorized();
            }
            
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username ?? ""),
                new Claim(ClaimTypes.Role, user.Role ?? "")
            };

            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenhandler.CreateToken(tokendescriptor);
            var tokenstring = tokenhandler.WriteToken(token);

            return Ok(new
            {
                Token = tokenstring
            });
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> Adduser([FromForm] UserDTO userdetails)
        {
            if (_context.Users.Any(u => u.Username == userdetails.Username))
            {
                return BadRequest("Username is already taken.");
            }
            var avatarpath = await Saveavatar(userdetails.Avatar);
            DateTime utcnow = DateTime.UtcNow;
            TimeZoneInfo pstzone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
            DateTime philippinetime = TimeZoneInfo.ConvertTimeFromUtc(utcnow, pstzone);
            var user = new User
            {
                Firstname = userdetails.Firstname,
                Middlename = userdetails.Middlename,
                Lastname = userdetails.Lastname,
                Role = userdetails.Role,
                Username = userdetails.Username,
                Email = userdetails.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userdetails.Password),
                Avatar = avatarpath,
                Status = "Active"
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("user-detail")]
        public async Task<ActionResult<User>> Getuserdetail()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("User not authenticated");
            }
            int userId = int.Parse(userIdClaim.Value);
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }
            return user;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusers()
        {
            return await _context.Users
                .AsNoTracking()
                .Select(u => new User
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Firstname = u.Firstname,
                    Middlename = u.Middlename,
                    Lastname = u.Lastname,
                    Role = u.Role,
                    Avatar = u.Avatar,
                    Status = u.Status
                })
                .ToListAsync();
        }

        private async Task<string?> Saveavatar(IFormFile? file)
        {
            if(file == null || file.Length == 0)
                return null;

            var avatarpath = @"C:\Users\jatabilog\Desktop\xxx\farmify_client\src\assets\avatars";
            if(!Directory.Exists(avatarpath))
            {
                Directory.CreateDirectory(avatarpath);
            }

            var uniquefilename = $"{Guid.NewGuid()}_{file.FileName}";
            var filepath = Path.Combine(avatarpath, uniquefilename);

            using (var filestream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }
            return $"assets/avatars/{uniquefilename}";
        }
        
    }
}
