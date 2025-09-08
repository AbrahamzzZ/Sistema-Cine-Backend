using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class ReseñanConfiguration : IEntityTypeConfiguration<Reseña>
    {
        public void Configure(EntityTypeBuilder<Reseña> entity)
        {
            entity.HasKey(e => e.IdResenia).HasName("PK__RESEÑA__1E423F0EB4EF2660");

            entity.ToTable("RESEÑA");

            entity.Property(e => e.IdResenia).HasColumnName("ID_RESENIA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.IdPelicula).HasColumnName("ID_PELICULA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.IdPelicula)
                .HasConstraintName("FK__RESEÑA__ID_PELIC__4E88ABD4");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__RESEÑA__ID_USUAR__4D94879B");
        }
    }
}
