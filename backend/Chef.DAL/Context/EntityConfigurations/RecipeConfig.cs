using System;
using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chef.DAL.Context.EntityConfigurations
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(r => r.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasMany(r => r.Reviews)
                .WithOne(r => r.Recipe)
                .HasForeignKey(r => r.RecipeId);

            builder.HasMany(r => r.Instructions)
                .WithOne(i => i.Recipe)
                .HasForeignKey(i => i.RecipeId);

            builder.HasMany(r => r.Components)
                .WithOne(rc => rc.Recipe)
                .HasForeignKey(rc => rc.RecipeId);

            builder.Property(a => a.CreatedAt)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                );
        }
    }
}
