using Microsoft.EntityFrameworkCore;

namespace LojinhaLegal.Data
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

		// Defina sua entidade Produto
		public class Produto
		{
			public int Id { get; set; }
			public string Nome { get; set; }
			public decimal Preco { get; set; }
			public string ImagemUrl { get; set; }
			public string Descricao { get; set; }
			public string Categoria { get; set; } // Você pode adicionar mais propriedades conforme necessário
		}

}
