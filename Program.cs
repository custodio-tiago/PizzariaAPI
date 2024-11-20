using Microsoft.EntityFrameworkCore;
using YourProjectName.Data;
using YourProjectName.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração dos serviços
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PizzaService>();

// Adiciona controladores
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
