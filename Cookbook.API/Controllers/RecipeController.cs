using Cookbook.API.Database;
using Cookbook.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly DatabaseContext _dbContext = new DatabaseContext();

    [HttpGet(Name = "GetRecipes")]
    public IEnumerable<Recipe> GetRecipes()
    {
        var recipes = _dbContext.Recipes.Include(recipe => recipe.Ingredients).ToList();

        return recipes;
    }

    [HttpGet("{recipeId}", Name = "GetRecipe")]
    public ActionResult GetRecipe(int recipeId)
    {
        var recipe = GetRecipeById(recipeId);

        if (recipe is null)
            return NotFound();

        return Ok(recipe);
    }

    [HttpPost(Name = "AddRecipe")]
    public string AddRecipe(Recipe recipe)
    {
        if (recipe.Title.Length == 0)
            return "Title must not be empty";

        if (recipe.Ingredients.Count == 0)
            return "Recipe must have at least one ingredient";

        _dbContext.Recipes.Add(recipe);
        _dbContext.SaveChanges();

        return "Yes";
    }

    [HttpDelete(Name = "DeleteRecipe")]
    public string DeleteRecipe(int recipeId)
    {
        var recipeToDelete = GetRecipeById(recipeId);
        if (recipeToDelete is not null)
        {
            _dbContext.Recipes.Remove(recipeToDelete);
            return "Deleted :(";
        }

        return "There is no recipe with provided ID";
        
    }

    private Recipe? GetRecipeById(int recipeId)
    {
        return _dbContext.Recipes.Include(recipe => recipe.Ingredients).FirstOrDefault(recipe => recipe.Id == recipeId);
    } 
}
