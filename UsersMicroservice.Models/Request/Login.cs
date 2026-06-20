using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersMicroservice.Models.Request
{
    /// <summary>
    /// Model klasy logowania do systemu
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Nazwa zarejestrowanego uzytkownika systemu
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Hasło użytkownika
        /// </summary>
        public string Password { get; set; }
    }
}
