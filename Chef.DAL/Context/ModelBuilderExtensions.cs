using Chef.DAL.Context.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Chef.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeConfig).Assembly);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            // set seed data
        }
    }
}
