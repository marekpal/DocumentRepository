using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UsersMicroservice.Models.Response;

namespace UsersMicroservice.Services
{

    public class UsersService
    {
        private readonly ApplicationContext.DocumentsContext db;

        public UsersService(ApplicationContext.DocumentsContext db)
        {
            this.db = db;
        }

        public async Task<List<User>> Users(int callerId)
        {
            //TODO: Pobrać z bazy danych

            List<Models.Response.User> users = new List<Models.Response.User>();

            var dbCaller = await db.Users
                .Include(x=>x.Company)
                .FirstOrDefaultAsync(x => x.Id == callerId);
            int companyId = dbCaller.Company.Id;


            List<ApplicationContext.Models.User> dbUsers = await db.Users
                .Include(x => x.Company)
                .Where(x => x.Company.Id == companyId)
                .ToListAsync();

            foreach (var dbUser in dbUsers)
            {
                users.Add(new Models.Response.User
                {
                    Id = dbUser.Id,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Username = dbUser.Username,
                    Company = new Models.Response.Company()
                    {
                        Name = dbUser.Company.Name
                    }
                });
            }

            return users;
        }

        public async Task<User> UserById(int id)
        {
            var dbUser = await db.Users
                .Include(x => x.Company)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dbUser == null)
                throw new ArgumentException("Użytkownika nie ma w bazie.");

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

            return found;
        }


        /// <summary>
        /// Logowanie do systemu
        /// </summary>
        /// <param name="credentials">Dane uwierzytelniające</param>
        /// <returns>Token dostępowy</returns>
        public async Task<Models.Response.Login> Login(Models.Request.Login credentials)
        {
            var dbUser = await db.Users
                .FirstOrDefaultAsync(x => (x.Username == credentials.UserName.Trim().ToLower())
                                        && (x.Password == credentials.Password));

            if (dbUser == null)
                throw new UnauthorizedAccessException();

            Models.Response.Login result = new Models.Response.Login();
            result.AccessToken = "";

            string key = "coś długiego jako klucz szyfrowania. Musim mieć 32 znaki";

            Claim[] claims = new Claim[] {
                new Claim(ClaimTypes.Name, $"{dbUser.FirstName} {dbUser.LastName}"),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim("user_id", dbUser.Id.ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(10),
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256)
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            result.AccessToken = tokenString;
            return result;
        }
    }
}
