using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersMicroservice.Models.Response
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? ZipCode { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }
    }
}
