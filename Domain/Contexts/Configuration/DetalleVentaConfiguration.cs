using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVentum>
    {
        public void Configure(EntityTypeBuilder<DetalleVentum> entity)
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DETALLE___49DABA0C67961753");

            entity.ToTable("DETALLE_VENTA");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("ID_DETALLE_VENTA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.IdBoleto).HasColumnName("ID_BOLETO");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
            entity.Property(e => e.PrecioVenta)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO_VENTA");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("SUBTOTAL");

            entity.HasOne(d => d.IdBoletoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdBoleto)
                .HasConstraintName("FK__DETALLE_V__ID_BO__06CD04F7");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DETALLE_V__ID_PR__05D8E0BE");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__DETALLE_V__ID_VE__04E4BC85");
        }
    }
}
