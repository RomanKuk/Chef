using System;
using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chef.DAL.Context.EntityConfigurations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(i => i.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                );
        }
    }
}
