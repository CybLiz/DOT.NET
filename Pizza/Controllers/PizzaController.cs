using Microsoft.AspNetCore.Mvc;
using Pizza.Models;
using Pizza.Repository;
using PizzaEntity = Pizza.Models.Pizza;

namespace Pizza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : Controller
{
    private readonly IRepository<PizzaEntity> _repository;

    public PizzaController(IRepository<PizzaEntity> repository)
    {
        _repository = repository;
    }

    // GET api/pizza
    [HttpGet]
    public IActionResult GetAll()
    {
        List<PizzaEntity> pizzas = _repository.GetAll();
        return Ok(pizzas);
    }

    // GET api/pizza/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var pizza = _repository.Get(id);
        if (pizza != null)
        {
            return Ok(pizza);
        }

        return NotFound(new
        {
            Message = "Pizza non trouvée"
        });
    }

    // POST api/pizza
    [HttpPost]
    public IActionResult Post([FromBody] PizzaEntity pizza)
    {
        return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);

    }

    // PUT api/pizza/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PizzaEntity pizza)
    {
        pizza.Id = id;
        bool updated = _repository.Update(pizza);

        if (!updated)
        {
            return NotFound(new
            {
                Message = "Pizza non trouvée"
            });
        }

        return Ok("Pizza mise à jour");
    }

    // DELETE api/pizza/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _repository.Delete(id);

        if (!deleted)
        {
            return NotFound(new
            {
                Message = "Pizza non trouvée"
            });
        }

        return Ok("Pizza supprimée");
    }
}
