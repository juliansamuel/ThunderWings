using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThunderWings.Domain.ProductRoles;

namespace ThunderWings.Infrastructure.Configurations;

internal class ProductRoleConfiguration : IEntityTypeConfiguration<ProductRole>
{
    public void Configure(EntityTypeBuilder<ProductRole> builder)
    {
        builder.HasKey(pr => pr.Id);

        builder.Property(pr => pr.Id).HasConversion(
            productRoleId => productRoleId.Value,
            value => new ProductRoleId(value));
    }
}
