using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using LojinhaLegal.Models.context;
using LojinhaLegal.Models.Repositories;
using lojinhaLegal.Repository.Interface;
using System.Configuration;



var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//        new MySqlServerVersion(new Version(8, 0, 23)))); // Ajuste a versão conforme sua instalação
void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IProdutoRepository, ProdutoRepository>();

    // Outros serviços
}
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
// Adicione o serviço do DbContext com a string de conexão do MySQL

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
