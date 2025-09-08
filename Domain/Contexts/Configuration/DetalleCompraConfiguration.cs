using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class DetalleCompraConfiguration : IEntityTypeConfiguration<DetalleCompra>
    {
        public void Configure(EntityTypeBuilder<DetalleCompra> entity)
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__DETALLE___2E6E01ED018107D7");

            entity.ToTable("DETALLE_COMPRA");

            entity.Property(e => e.IdDetalleCompra).HasColumnName("ID_DETALLE_COMPRA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.PrecioCompra)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO_COMPRA");
            entity.Property(e => e.PrecioVenta)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO_VENTA");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("SUBTOTAL");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK__DETALLE_C__ID_CO__778AC167");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DETALLE_C__ID_PR__787EE5A0");
        }
    }
}
