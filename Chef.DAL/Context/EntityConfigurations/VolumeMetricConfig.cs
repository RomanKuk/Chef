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
    public class VolumeMetricConfig : IEntityTypeConfiguration<VolumeMetric>
    {
        public void Configure(EntityTypeBuilder<VolumeMetric> builder)
        {
            builder.Property(vm => vm.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
