using System;
using System.Collections.Generic;
using System.Text;

namespace UsersMicroservice.Models.Response
{
    /// <summary>
    /// Klasa użytkownika systemu
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identyfiaktor użytkownika w systemie
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa użytkownika (login, email)
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Imię uzytkownika
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Nazwisko użytkownika
        /// </summary>
        public string? LastName { get; set; }

        public Company Company { get; set; }
    }
}
