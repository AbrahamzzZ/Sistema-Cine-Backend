using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> entity)
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__MENU__4728FC6007A98D67");

            entity.ToTable("MENU");

            entity.Property(e => e.IdMenu).HasColumnName("ID_MENU");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.UrlMenu)
                .HasMaxLength(100)
                .HasColumnName("URL_MENU");
        }
    }
}
