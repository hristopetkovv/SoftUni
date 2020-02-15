namespace Andreys.Data
{
    using Microsoft.EntityFrameworkCore;

    using Andreys.Models;

    public class AndreysDbContext : DbContext
    {
        public AndreysDbContext()
        {
                
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=I4KOWE\SQLEXPRESS;Database=Andreys;Integrated Security=true");
        }
    }
}
