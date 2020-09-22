using LembreMeServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LembreMeServer.Infra.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder.OwnsOne(t => t.Location, location =>
            {
                location.Property(l => l.City)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                location.Property(l => l.FederativeUnit)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                location.Property(l => l.Neighborhood)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                location.Property(l => l.Street)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");
            });
        }
    }
}
