using Cookbook.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.API.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string dbName = "cookbookDB.db";
        string dbPath = Path.Combine(userPath, dbName);
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
