using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using zbs_gp_project.Interfaces;
using zbs_gp_project.Models;
using zbs_gp_project.Repository;

namespace zbs_gp_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _cfg;
        private readonly IUserRepository _userRepository;
        public AuthController(IConfiguration cfg, IUserRepository userRepository)
        {
            _cfg = cfg;
            _userRepository = userRepository;
        }
        public record LoginDto(string Email, string Password);
        public record RegisterDto(string Email, string Password);

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ct)
        {
            var email = dto.Email.Trim().ToLowerInvariant();

            var user = await _userRepository.GetUserByEmail(email, ct);

            if(user is null) return Unauthorized();

           
            if(user.Password!= dto.Password) return Unauthorized();

            var jwtSection = _cfg.GetSection("Jwt");  // get jwt configuration from appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSection["AccessTokenMinutes"]!)),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { access_token = jwt });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ct)
        {
            var email = dto.Email.Trim().ToLowerInvariant();

            var exist = await _userRepository.GetUserByEmail(email,ct);
            if (exist is not null)
            {
                return Conflict("user already exist");
            }



            var user = new User { Email = email, Password = dto.Password, Id = $"userid-{Guid.NewGuid().ToString("N")}", Name = $"username-{email}", UserTimeStamp = DateTime.Now };

            await _userRepository.AddAsync(user, ct);
            return CreatedAtAction(nameof(Register), new { email = user.Email }, new { message = "Registered" });
        }
    }
}
