using Pizza.Repository;
using Pizza.Models;
using Pizza.Data;
using Microsoft.EntityFrameworkCore;
using PizzaEntity = Pizza.Models.Pizza;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<PizzaEntity>, PizzaRepository>();

string connectionString = "Server=localhost;Database=Pizzas;User ID=root;Password=password;";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

// Configure Swagger for development (or always if you want)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza API V1");
    c.RoutePrefix = "swagger"; // L’UI sera accessible à /swagger
});

app.UseAuthorization();
app.MapControllers();

app.Run();
