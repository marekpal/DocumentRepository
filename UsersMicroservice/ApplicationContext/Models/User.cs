using System.ComponentModel.DataAnnotations;

namespace UsersMicroservice.ApplicationContext.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        public string Password { get; set; }

        public Company Company { get; set; }
    }
}
