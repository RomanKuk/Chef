using System;
using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chef.DAL.Context.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.HasIndex(u => u.UId)
                .IsUnique();

            builder.Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasMaxLength(128);

            builder.Property(u => u.LastName)
                .HasMaxLength(128);

            builder.Property(u => u.Email)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                );
        }
    }
}
