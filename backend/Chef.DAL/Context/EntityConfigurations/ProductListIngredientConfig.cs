using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chef.DAL.Context.EntityConfigurations
{
    public class ProductListIngredientConfig : IEntityTypeConfiguration<ProductListIngredient>
    {
        public void Configure(EntityTypeBuilder<ProductListIngredient> builder)
        {
            builder.Property(ci => ci.Description)
                .HasMaxLength(128);
        }
    }
}
