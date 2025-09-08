using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__PRODUCTO__88BD0357C14215A7");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.PrecioCompra)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO_COMPRA");
            entity.Property(e => e.PrecioVenta)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO_VENTA");
            entity.Property(e => e.Stock).HasColumnName("STOCK");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("TIPO");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__PRODUCTO__ID_CAT__693CA210");
        }
    }
}
