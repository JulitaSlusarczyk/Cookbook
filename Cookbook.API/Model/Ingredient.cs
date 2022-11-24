namespace Cookbook.API.Model;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public Unit Unit { get; set; }

}
