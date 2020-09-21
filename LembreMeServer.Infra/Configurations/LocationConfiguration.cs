using LembreMeServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LembreMeServer.Infra.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Neighborhood)
                .HasMaxLength(100)
                .HasColumnType("varchar");
            builder.Property(l => l.City)
                .HasMaxLength(100)
                .HasColumnType("varchar");
            builder.Property(l => l.FederativeUnit)
                .HasMaxLength(100)
                .HasColumnType("varchar");
            builder.Property(l => l.Street)
                .HasMaxLength(100)
                .HasColumnType("varchar");
            builder.Property(l => l.Number)
                .HasDefaultValue(0);
        }
    }
}
