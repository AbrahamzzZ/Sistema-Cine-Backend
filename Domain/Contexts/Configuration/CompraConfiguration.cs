using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class CompraConfiguration : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> entity)
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__COMPRA__16C0FA95DCED53D2");

            entity.ToTable("COMPRA");

            entity.HasIndex(e => e.NumeroDocumento, "UQ__COMPRA__87B6EC7E46381EE7").IsUnique();

            entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPRA");
            entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");
            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.IdTransportista).HasColumnName("ID_TRANSPORTISTA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MONTO_TOTAL");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_DOCUMENTO");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .HasColumnName("TIPO_DOCUMENTO");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__COMPRA__ID_PROVE__72C60C4A");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdSucursal)
                .HasConstraintName("FK__COMPRA__ID_SUCUR__71D1E811");

            entity.HasOne(d => d.IdTransportistaNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdTransportista)
                .HasConstraintName("FK__COMPRA__ID_TRANS__73BA3083");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__COMPRA__ID_USUAR__70DDC3D8");
        }
    }
}
