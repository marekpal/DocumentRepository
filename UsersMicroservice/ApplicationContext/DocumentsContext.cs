using Microsoft.EntityFrameworkCore;
using UsersMicroservice.ApplicationContext.Models;

namespace UsersMicroservice.ApplicationContext
{
    public class DocumentsContext : DbContext
    {
        public DocumentsContext(DbContextOptions<DocumentsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

    }
}
