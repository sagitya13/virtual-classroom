/*using classroom.models;
using classroom.services; 
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using System.Threading.Tasks;

using static System.Net.WebRequestMethods;
 
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;
        private readonly IConfiguration _config;
        public UsersController(UsersService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }




        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Users model)
        {
            try
            {
                var user = _userService.AuthenticateUser(model.Name, model.Password);

                if (user != null)
                {
                    SHA256 sha256Hash = SHA256.Create();
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    string hashedPassword = builder.ToString();

                    if (user.Password == hashedPassword)
                    {
                        return Ok(new { message = "Logged!", u = user });
                    }
                    else
                    {
                        return Unauthorized(new { message = "Invalid Password", u = new Users() });
                    }
                }
                else
                {
                    return NotFound(new { message = "Invalid Password", u = new Users() });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

            private string GenerateToken(Users user)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null, expires: DateTime.UtcNow.AddMinutes(1), signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }

        [HttpPost("signup")]
        public  IActionResult signup([FromBody] Users model)
        {
            try
            {
                _userService.CreateUser(model);
              

                
            }
            catch (Exception ex)
            {
               
            }
            return Ok();
        }

    }
}*/


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using classroom.services;

using System.Security.Cryptography;
using classroom.models;

namespace classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;
        private readonly IConfiguration _config;

        public UsersController(UsersService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Users model)
        {
            try
            {
                var user = _userService.AuthenticateUser(model.Name, model.Password);

                if (user != null)
                { 
                    SHA256 sha256Hash = SHA256.Create();
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    string hashedPassword = builder.ToString();

                    if (user.Password == hashedPassword)
                    {
                        var token = GenerateToken(user);
                        return Ok(new { token, user });
                    }
                    else
                    {
                        return Unauthorized(new { message = "Invalid Password", user = new Users() });
                    }
                }
                else
                {
                    return NotFound(new { message = "Invalid Password", user = new Users() });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        private string GenerateToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                // Add additional claims as needed
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30), // Set the token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] Users model)
        {
            try
            {
                _userService.CreateUser(model);
                // Any additional logic for user signup
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}