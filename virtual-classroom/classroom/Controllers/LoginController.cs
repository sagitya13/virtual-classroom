using classroom.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    
    public class loginController : ControllerBase
    {
        private IConfiguration _config;
        public loginController(IConfiguration configuration)
        {
            _config = configuration;
        }
        private Users AuthenticateUser (login user) 
        {
            Users _login = null;
            if(user.Username == "admin" && user.Password=="12345") {

                _login = new Users {Name = "sagitya" };
            }
            return _login;
        }
        private string GenerateToken(Users logins)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credeentials =new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null, expires: DateTime.UtcNow.AddMinutes(1), signingCredentials: credeentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(login users)
        {
            IActionResult response = Unauthorized();
            var login_ = AuthenticateUser(users);
            if(login_ != null)
            {
                var token =GenerateToken(login_);
                response = Ok(new { token = token });
            }
            return response;
        }
    }
}
