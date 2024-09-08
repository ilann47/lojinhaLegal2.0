using Microsoft.EntityFrameworkCore;
using ProjetoVitrineECOMERCE.Data;
using ProjetoVitrineECOMERCE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configura o contexto para usar MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 32))));

builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configura o redirecionamento da rota inicial para a página "Bones"
app.MapGet("/", context =>
{
    context.Response.Redirect("/Bones");
    return Task.CompletedTask;
});

app.MapRazorPages();

app.Run();
