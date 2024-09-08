using Microsoft.EntityFrameworkCore;
using ProjetoVitrineECOMERCE.Models;

namespace ProjetoVitrineECOMERCE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Bone> Bones { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItems { get; set; }
    }
}
