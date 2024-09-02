using Microsoft.EntityFrameworkCore;

namespace LojinhaLegalV3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Defina DbSets para suas entidades
        public DbSet<Produto> Produtos { get; set; }
    }

    
    

}
