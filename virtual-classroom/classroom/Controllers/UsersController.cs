using classroom.models;
using classroom.services;
using classroom.services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;

        public UsersController(UsersService userService)
        {
            _userService = userService;
        }




        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            try
            {
                var user = _userService.GetById(model.Name);

                if (user != null)
                {
                    // Check if the passwords match
                    if (user.Password == model.Password)
                    {
                        // If the passwords match, return the user data
                        return Ok(user);
                    }
                    else
                    {
                        // If the passwords do not match, return null or an appropriate response
                        return Unauthorized("Invalid password");
                    }
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }

    }
}