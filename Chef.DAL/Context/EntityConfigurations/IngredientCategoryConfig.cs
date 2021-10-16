using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chef.DAL.Context.EntityConfigurations
{
    public class IngredientCategoryConfig : IEntityTypeConfiguration<IngredientCategory>
    {
        public void Configure(EntityTypeBuilder<IngredientCategory> builder)
        {
            builder.Property(ic => ic.Name)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
