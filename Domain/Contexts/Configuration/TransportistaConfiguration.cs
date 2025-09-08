using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class TransportistaConfiguration : IEntityTypeConfiguration<Transportistum>
    {
        public void Configure(EntityTypeBuilder<Transportistum> entity)
        {
            entity.HasKey(e => e.IdTransportista).HasName("PK__TRANSPOR__057F895CC8BF1F8B");

            entity.ToTable("TRANSPORTISTA");

            entity.Property(e => e.IdTransportista).HasColumnName("ID_TRANSPORTISTA");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CEDULA");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Foto).HasColumnName("FOTO");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_COMPLETO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        }
    }
}
