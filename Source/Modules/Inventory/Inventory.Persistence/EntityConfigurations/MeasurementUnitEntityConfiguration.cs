using Inventory.Domain.MeasurementUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Persistence.EntityConfigurations;

public class MeasurementUnitEntityConfiguration : IEntityTypeConfiguration<MeasurementUnit>
{
    public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
    {
        builder.HasKey(mu => mu.Id);
        builder.Property(mu => mu.Id).ValueGeneratedNever().HasColumnOrder(0);

        builder.ComplexProperty(mu => mu.MeasurementUnitName, builder =>
        {
            builder.Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(20)
                .IsRequired();
        });

        builder.ComplexProperty(mu => mu.MeasurementUnitAbbreviation, builder =>
        {
            builder.Property(a => a.Value)
                .HasColumnName("Abbreviation")
                .HasMaxLength(3)
                .IsRequired();
        });
    }
}