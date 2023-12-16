using BaltaDesafioBlazor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaltaDesafioBlazor.Infra.Data.Map;

public class LocalityMap : IEntityTypeConfiguration<Locality>
{
    public void Configure(EntityTypeBuilder<Locality> builder)
    {
        builder.ToTable("IBGE");

        builder.HasKey(x => x.Id);

        builder.Property(i => i.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("CHAR")
            .HasMaxLength(7);

        builder.Property(i => i.State)
            .IsRequired()
            .HasColumnName("State")
            .HasColumnType("CHAR")
            .HasMaxLength(2);
        builder.HasIndex(i => i.State, "IX_IBGE_State");

        builder.Property(i => i.City)
            .IsRequired()
            .HasColumnName("City")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        builder.HasIndex(i => i.City, "IX_IBGE_City");
    }
}
