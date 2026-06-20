using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersMicroservice.ApplicationContext;

namespace UsersMicroservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DocumentsContext db;
        public UsersController(DocumentsContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<List<Models.Response.User>> GetUsers()
        {
            //TODO: Pobrać z bazy danych

            List<Models.Response.User> users = new List<Models.Response.User>()
            {
                new Models.Response.User()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Słodowy",
                    Username = "adam@firma.pl"
                },
                new Models.Response.User() {
                     Id = 2,
                    FirstName = "Bartłomiej",
                    LastName = "Piwo",
                    Username = "bartlomiej@firma.pl"
                },
                new Models.Response.User() {
                     Id = 3,
                    FirstName = "Cezary",
                    LastName = "Szybki",
                    Username = "cezary@firma.pl"
                }
            };

            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Response.User>> GetUser(int id)
        {
            //TODO: Pobrać z bazy danych

            var dbUser = await db.Users
                .Include(x=>x.Company)
                .FirstOrDefaultAsync(x => x.Id == id);

            Models.Response.User found = new Models.Response.User()
            {
                Id = dbUser.Id,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                Username = dbUser.Username,
                Company = new Models.Response.Company()
                {
                    Name = dbUser.Company.Name
                }
        
            };

            return Ok(found);

        }
    }
}
