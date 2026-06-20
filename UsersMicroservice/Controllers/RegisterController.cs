using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersMicroservice.ApplicationContext;

namespace UsersMicroservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly DocumentsContext db;

        public RegisterController(DocumentsContext db)
        {
            this.db = db;
        }

        [HttpPost("User")]
        public async Task<ActionResult> RegisterUser([FromBody] UsersMicroservice.Models.Request.UserRegister newUser)
        {
            if (newUser.FirstName.ToLower().Trim() == "stefan")
            {
                return BadRequest("Nie lubimy Stefanów");
            }

            if (newUser.Password.Length < 12)
            {
                return BadRequest("Password too short");
            }

            //TODO: Zapisać w bazie danych
            db.Users.Add(new ApplicationContext.Models.User()
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Username = newUser.Username,
                Password = newUser.Password
            });

            await db.SaveChangesAsync();

            return Ok();
        }
    }
}
