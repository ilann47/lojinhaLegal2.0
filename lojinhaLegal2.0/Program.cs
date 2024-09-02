using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LojinhaLegal.Data;




var builder = WebApplication.CreateBuilder(args);

// Adicione o servi�o do DbContext com a string de conex�o do MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
		new MySqlServerVersion(new Version(8, 0, 23)))); // Ajuste a vers�o conforme sua instala��o

// Adicione os servi�os da Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();


// Adicionar dados ao banco de dados durante a inicializa��o
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	try
	{
		SeedData.Initialize(services);
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred seeding the DB.");
	}
}
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
