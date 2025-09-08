using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categorium>
    {
        public void Configure(EntityTypeBuilder<Categorium> entity)
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__4BD51FA54D640D4D");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .HasColumnName("NOMBRE_CATEGORIA");
        }
    }
}
