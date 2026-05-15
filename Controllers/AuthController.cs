using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt; // For JwtSecurityTokenHandler
using System.Security.Claims;          // For Claim and ClaimTypes
using System.Text;
using EntityApp.Models; // Change this to your actual namespace
using EntityApp.Data;   // Change this to your DbContext namespace

namespace EntityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;

        public AuthController(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // 1. Validate the user against the database
            var user = _context.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

            if (user != null)
            {
                // 2. Generate the token
                var token = GenerateJWT(user);
                return Ok(new { token = token, message = "Login Success" });
            }

            return Unauthorized("Invalid credentials");
        }

        private string GenerateJWT(User user)
        {
            // Ensure you use System.Text.Encoding.UTF8 specifically
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Claims are the pieces of data encoded inside the token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.userId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", user.Fullname)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // Simple DTO for the login request
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}