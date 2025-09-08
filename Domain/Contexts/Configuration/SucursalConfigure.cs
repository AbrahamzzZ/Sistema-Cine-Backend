using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class SucursalConfigure : IEntityTypeConfiguration<Sucursal>
    {
        public void Configure(EntityTypeBuilder<Sucursal> entity)
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__SUCURSAL__AB3873839F4C5670");

            entity.ToTable("SUCURSAL");

            entity.HasIndex(e => e.Codigo, "UQ__SUCURSAL__CC87E126BC653634").IsUnique();

            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CIUDAD");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Ruc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RUC");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        }
    }
}
