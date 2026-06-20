using System.ComponentModel.DataAnnotations;

namespace UsersMicroservice.ApplicationContext.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? ZipCode { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public List<User> Users { get; set; }
    }
}
