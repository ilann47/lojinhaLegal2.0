using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LojinhaLegalV3.Data
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
                    Console.WriteLine("DB já foi populado");
                    return;   // DB já foi populado
                }

                Console.WriteLine("Populando o banco de dados...");

                // Adicione produtos
                context.Produtos.AddRange(
                    new Produto
                    {
                        Nome = "bone teste",
                        Preco = 19.99M,
                        Imagem = "produto1.jpg",
                        Descricao = "Descrição do Produto 1",
                        Categoria = "Categoria A"
                    },
                    new Produto
                    {
                        Nome = "Produto 24",
                        Preco = 29.99M,
                        Imagem = "produto2.jpg",
                        Descricao = "Descrição do Produto 2",
                        Categoria = "Categoria B"
                    }
                );
                context.SaveChanges();
                Console.WriteLine("Banco de dados populado.");
            }
        }

    }
    }
