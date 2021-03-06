using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chef.DAL.Context.EntityConfigurations
{
    public class ProductListConfig : IEntityTypeConfiguration<ProductList>
    {
        public void Configure(EntityTypeBuilder<ProductList> builder)
        {
            builder.HasMany(pl => pl.Ingredients)
                .WithOne(pli => pli.ProductList)
                .HasForeignKey(pli => pli.ProductListId);
        }
    }
}
