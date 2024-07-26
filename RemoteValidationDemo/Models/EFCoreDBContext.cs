using Microsoft.EntityFrameworkCore;

namespace RemoteValidationDemo.Models
{
    public class EFCoreDBContext : DbContext
    {
        public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
