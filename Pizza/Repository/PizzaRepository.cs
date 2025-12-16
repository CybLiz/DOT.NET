using Pizza.Data;
using Pizza.Models;
using PizzaEntity = Pizza.Models.Pizza;

namespace Pizza.Repository;

public class PizzaRepository : IRepository<PizzaEntity>
{
    private readonly AppDbContext _db;

    public PizzaRepository(AppDbContext db)
    {
        _db = db;
    }

    public bool Create(PizzaEntity entity)
    {
        _db.Pizzas.Add(entity);
        _db.SaveChanges();
        return true;
    }

    public PizzaEntity? Get(int id)
    {
        return _db.Pizzas.Find(id);
    }

    public List<PizzaEntity> GetAll()
    {
        return _db.Pizzas.ToList();
    }

    public bool Update(PizzaEntity entity)
    {
        PizzaEntity? pizzaFound = Get(entity.Id);
        if (pizzaFound == null)
            return false;

        pizzaFound.Description = entity.Description;
        pizzaFound.Status = entity.Status;
        pizzaFound.Ingredients = entity.Ingredients;

        _db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        PizzaEntity? pizzaFound = Get(id);
        if (pizzaFound == null)
            return false;

        _db.Pizzas.Remove(pizzaFound);
        _db.SaveChanges();
        return true;
    }
}
