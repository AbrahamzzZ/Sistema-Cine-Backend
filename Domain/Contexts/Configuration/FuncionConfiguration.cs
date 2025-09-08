using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class FuncionConfiguration : IEntityTypeConfiguration<Funcion>
    {
        public void Configure(EntityTypeBuilder<Funcion> entity)
        {
            entity.HasKey(e => e.IdFuncion).HasName("PK__FUNCION__40D41A0157EB671A");

            entity.ToTable("FUNCION");

            entity.Property(e => e.IdFuncion).HasColumnName("ID_FUNCION");
            entity.Property(e => e.FechaHoraFin)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_FIN");
            entity.Property(e => e.FechaHoraInicio)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_INICIO");
            entity.Property(e => e.IdPelicula).HasColumnName("ID_PELICULA");
            entity.Property(e => e.IdSala).HasColumnName("ID_SALA");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdPelicula)
                .HasConstraintName("FK__FUNCION__ID_PELI__52593CB8");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdSala)
                .HasConstraintName("FK__FUNCION__ID_SALA__534D60F1");
        }
    }
}
