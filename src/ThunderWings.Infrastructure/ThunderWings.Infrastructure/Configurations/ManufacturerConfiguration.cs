using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThunderWings.Domain.Manufacturers;

namespace ThunderWings.Infrastructure.Configurations;

internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).HasConversion(
            manufacturerId => manufacturerId.Value,
            value => new ManufacturerId(value));

        builder.Property(m => m.Name)
            .HasMaxLength(200);
    }
}
