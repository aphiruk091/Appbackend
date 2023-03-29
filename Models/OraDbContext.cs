using Microsoft.EntityFrameworkCore;
namespace appbackend.Models
{
    public class OraDbContext:DbContext
    {
        public DbSet<Fruit> Fruits { get; set; }
        public OraDbContext(DbContextOptions<OraDbContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}