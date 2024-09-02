using LojinhaLegal.Models.entity;
using Microsoft.EntityFrameworkCore;

namespace LojinhaLegal.Models.context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Produto> ProdutoEntity { get; set; }
    }
}