namespace Pizza.Models;

public class Pizza
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public PizzaStatus Status { get; set; }

    public List<Ingredient> Ingredients { get; set; }

    public override string ToString()
    {
        return $"Pizza {Id} - {Name} ({Status})";
    }
}

public enum PizzaStatus
{
    Vegan,
    Spicy
}
