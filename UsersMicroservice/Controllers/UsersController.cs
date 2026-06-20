using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using UsersMicroservice.ApplicationContext;
using UsersMicroservice.ApplicationContext.Models;
using UsersMicroservice.Services;

namespace UsersMicroservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        //private readonly DocumentsContext db;
        private readonly UsersService usersService;

        public UsersController(/*DocumentsContext db, */UsersService usersService)
        {
            //this.db = db;
            this.usersService = usersService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<Models.Response.User>>> GetUsers()
        {
            string role = User.FindFirst(ClaimTypes.Role)?.Value;
            string id = User.FindFirst("user_id")?.Value;

            List<Models.Response.User> users = await usersService.Users(int.Parse(id));

            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Response.User>> GetUser(int id)
        {
            Models.Response.User found = null;
            try
            {
                found = await usersService.UserById(id);
            }
            catch(UnauthorizedAccessException ex)
            {
                return Unauthorized();
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }

            return Ok(found);

        }
    }
}
