using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chef.DAL.Context.EntityConfigurations
{
    public class RecipeCategoryConfig : IEntityTypeConfiguration<RecipeCategory>
    {
        public void Configure(EntityTypeBuilder<RecipeCategory> builder)
        {
            builder.Property(ci => ci.Name)
                .HasMaxLength(128);
        }
    }
}
