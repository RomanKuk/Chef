using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chef.DAL.Context
{
    public class ChefContext : DbContext
    {
        public DbSet<ComponentIngredient> ComponentIngredients { get; private set; }
        public DbSet<Ingredient> Ingredients { get; private set; }
        public DbSet<IngredientCategory> IngredientCategories { get; private set; }
        public DbSet<Instruction> Instructions { get; private set; }
        public DbSet<ProductList> ProductLists { get; private set; }
        public DbSet<ProductListIngredient> ProductListIngredients { get; private set; }
        public DbSet<Recipe> Recipes { get; private set; }
        public DbSet<RecipeCategory> RecipeCategories { get; private set; }
        public DbSet<Review> Reviews { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<VolumeMetric> VolumeMetrics { get; private set; }

        public ChefContext(DbContextOptions<ChefContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
            modelBuilder.Seed();
        }
    }
}
