using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Core.Domain.Entities;

namespace POS.Infrastructure.Persistence.Configurations
{
    public class MeasurementUnitConfig : IEntityTypeConfiguration<MeasurementUnit>
    {
        public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
        {
            builder.Property(mu => mu.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(mu => mu.Abbreviation)
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
