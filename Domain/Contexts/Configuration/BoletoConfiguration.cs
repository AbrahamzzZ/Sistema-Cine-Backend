using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexts.Configuration
{
    public class BoletoConfiguration : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> entity)
        {
            entity.HasKey(e => e.IdBoleto).HasName("PK__BOLETO__8FAA98499130BCF9");

            entity.ToTable("BOLETO");

            entity.Property(e => e.IdBoleto).HasColumnName("ID_BOLETO");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPRA");
            entity.Property(e => e.IdAsiento).HasColumnName("ID_ASIENTO");
            entity.Property(e => e.IdFuncion).HasColumnName("ID_FUNCION");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.IdAsientoNavigation).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.IdAsiento)
                .HasConstraintName("FK__BOLETO__ID_ASIEN__5CD6CB2B");

            entity.HasOne(d => d.IdFuncionNavigation).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.IdFuncion)
                .HasConstraintName("FK__BOLETO__ID_FUNCI__5BE2A6F2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__BOLETO__ID_USUAR__5AEE82B9");
        }
    }
}
