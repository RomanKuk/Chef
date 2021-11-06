using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chef.DAL.Context.EntityConfigurations
{
    public class RecipeComponentConfig : IEntityTypeConfiguration<RecipeComponent>
    {
        public void Configure(EntityTypeBuilder<RecipeComponent> builder)
        {
            builder.HasMany(rc => rc.Ingredients)
                .WithOne(i => i.RecipeComponent)
                .HasForeignKey(rc => rc.RecipeComponentId);
        }
    }
}
