using Pizza.Models;
using Microsoft.EntityFrameworkCore;
using PizzaEntity = Pizza.Models.Pizza;


namespace Pizza.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<PizzaEntity> Pizzas { get; set; }

}