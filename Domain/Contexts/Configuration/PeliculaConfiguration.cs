using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class PeliculaConfiguration : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> entity)
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK__PELICULA__65888127CB384AED");

            entity.ToTable("PELICULA");

            entity.Property(e => e.IdPelicula).HasColumnName("ID_PELICULA");
            entity.Property(e => e.Duracion).HasColumnName("DURACION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.GeneroPelicula)
                .HasMaxLength(50)
                .HasColumnName("GENERO_PELICULA");
            entity.Property(e => e.NombrePelicula)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_PELICULA");
            entity.Property(e => e.Poster).HasColumnName("POSTER");
        }
    }
}
