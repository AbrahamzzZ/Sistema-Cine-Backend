using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class SalaConfiguration : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> entity)
        {
            entity.HasKey(e => e.IdSala).HasName("PK__SALA__E8F6CE89A8DFBE21");

            entity.ToTable("SALA");

            entity.Property(e => e.IdSala).HasColumnName("ID_SALA");
            entity.Property(e => e.EspacioSala).HasColumnName("ESPACIO_SALA");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("TIPO");
        }
    }
}
