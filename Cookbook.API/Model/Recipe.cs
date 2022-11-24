using System.ComponentModel.DataAnnotations;

namespace Cookbook.API.Model;

public class Recipe
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public Difficulty Difficulty { get; set; }

    public string Preparation { get; set; } = string.Empty;

}

