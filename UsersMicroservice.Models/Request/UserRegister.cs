using System;
using System.Collections.Generic;
using System.Text;

namespace UsersMicroservice.Models.Request
{
    public class UserRegister
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

    }
}
