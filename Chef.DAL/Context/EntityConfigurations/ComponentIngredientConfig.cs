using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chef.DAL.Context.EntityConfigurations
{
    public class ComponentIngredientConfig : IEntityTypeConfiguration<ComponentIngredient>
    {
        public void Configure(EntityTypeBuilder<ComponentIngredient> builder)
        {
            builder.Property(ci => ci.Description)
                .HasMaxLength(128);
        }
    }
}
