﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThunderWings.Domain.Products;

namespace ThunderWings.Infrastructure.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            value => new ProductId(value));

        builder.Property(p => p.Name)
            .HasMaxLength(200);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TopSpeed)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Country)
            .WithMany()
            .HasForeignKey(p => p.CountryId);

        builder.HasOne(p => p.Manufacturer)
            .WithMany()
            .HasForeignKey(p => p.ManufacturerId);

        builder.HasOne(p => p.ProductRole)
            .WithMany()
            .HasForeignKey(p => p.ProductRoleId);
    }
}
