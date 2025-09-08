using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class PermisoConfiguration : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> entity)
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__PERMISO__AC74EBF6DEC40C48");

            entity.ToTable("PERMISO");

            entity.Property(e => e.IdPermiso).HasColumnName("ID_PERMISO");
            entity.Property(e => e.IdMenu).HasColumnName("ID_MENU");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__PERMISO__ID_MENU__46E78A0C");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__PERMISO__ID_ROL__45F365D3");
        }
    }
}
