namespace Pizza.Models;

public class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public override string ToString()
    {
        return $"Ingredient {Id} - {Name}";
    }
}
