using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class AsientoConfiguration : IEntityTypeConfiguration<Asiento>
    {
        public void Configure(EntityTypeBuilder<Asiento> entity)
        {
            entity.HasKey(e => e.IdAsiento).HasName("PK__ASIENTO__0C03A733B8332470");

            entity.ToTable("ASIENTO");

            entity.HasIndex(e => e.Numero, "UQ__ASIENTO__7500EDCB1E8CD72E").IsUnique();

            entity.HasIndex(e => e.Fila, "UQ__ASIENTO__9C29646CCEEE5F20").IsUnique();

            entity.Property(e => e.IdAsiento).HasColumnName("ID_ASIENTO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fila)
                .HasMaxLength(10)
                .HasColumnName("FILA");
            entity.Property(e => e.IdSala).HasColumnName("ID_SALA");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("NUMERO");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Asientos)
                .HasForeignKey(d => d.IdSala)
                .HasConstraintName("FK__ASIENTO__ID_SALA__5812160E");
        }
    }
}
