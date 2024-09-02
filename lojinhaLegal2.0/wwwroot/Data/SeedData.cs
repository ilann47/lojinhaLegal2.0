using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LojinhaLegal.Data
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new AppDbContext(
				serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
			{
				// Verifica se existem produtos na base de dados
				if (context.Produtos.Any())
				{
					return;   // DB já foi populado
				}

				// Adicione produtos
				context.Produtos.AddRange(
					new Produto
					{
						Nome = "Produto 1",
						Preco = 19.99M,
						ImagemUrl = "produto1.jpg",
						Descricao = "Descrição do Produto 1",
						Categoria = "Categoria A"
					},
					new Produto
					{
						Nome = "Produto 2",
						Preco = 29.99M,
						ImagemUrl = "produto2.jpg",
						Descricao = "Descrição do Produto 2",
						Categoria = "Categoria B"
					}
				);
				context.SaveChanges();
			}
		}
	}
}
