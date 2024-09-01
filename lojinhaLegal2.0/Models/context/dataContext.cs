using LojinhaLegal.Models.entity;
using Microsoft.EntityFrameworkCore;

namespace LojinhaLegal.Models.context
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext> options)
            : base(options)
        {
            if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();

            }
        }

        public DbSet<Produto> ProdutoEntity { get; set; }
    }
}