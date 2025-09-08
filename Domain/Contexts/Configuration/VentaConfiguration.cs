using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class VentaConfiguration : IEntityTypeConfiguration<Ventum>
    {
        public void Configure(EntityTypeBuilder<Ventum> entity)
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__VENTA__F3B6C1B412DFDD76");

            entity.ToTable("VENTA");

            entity.HasIndex(e => e.NumeroDocumento, "UQ__VENTA__87B6EC7EDADE2DE6").IsUnique();

            entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_VENTA");
            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.MontoCambio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MONTO_CAMBIO");
            entity.Property(e => e.MontoPago)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MONTO_PAGO");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MONTO_TOTAL");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_DOCUMENTO");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .HasColumnName("TIPO_DOCUMENTO");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(20)
                .HasColumnName("TIPO_PAGO");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdSucursal)
                .HasConstraintName("FK__VENTA__ID_SUCURS__00200768");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__VENTA__ID_USUARI__7F2BE32F");
        }
    }
}
