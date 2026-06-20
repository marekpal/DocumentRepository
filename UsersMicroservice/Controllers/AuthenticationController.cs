using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersMicroservice.Services;

namespace UsersMicroservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UsersService usersService;

        public AuthenticationController(UsersService usersService)
        {
            this.usersService = usersService;
        }

       
        [HttpPost("Login")]
        public async Task<ActionResult<Models.Response.Login>> Login([FromBody] Models.Request.Login credentials)
        {
            try
            {
                var result = await usersService.Login(credentials);

                return result;
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
