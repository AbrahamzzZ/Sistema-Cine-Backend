using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Contexts;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asiento> Asientos { get; set; }

    public virtual DbSet<Boleto> Boletos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Funcion> Funcions { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Reseña> Reseñas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Transportistum> Transportista { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8CQM9OG\\SQLSEXPRESS;Database=SISTEMA_CINE;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asiento>(entity =>
        {
            entity.HasKey(e => e.IdAsiento).HasName("PK__ASIENTO__0C03A733B8332470");

            entity.ToTable("ASIENTO");

            entity.HasIndex(e => e.Numero, "UQ__ASIENTO__7500EDCB1E8CD72E").IsUnique();

            entity.HasIndex(e => e.Fila, "UQ__ASIENTO__9C29646CCEEE5F20").IsUnique();

            entity.Property(e => e.IdAsiento).HasColumnName("ID_ASIENTO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fila)
                .HasMaxLength(10)
                .HasColumnName("FILA");
            entity.Property(e => e.IdSala).HasColumnName("ID_SALA");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("NUMERO");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Asientos)
                .HasForeignKey(d => d.IdSala)
                .HasConstraintName("FK__ASIENTO__ID_SALA__5812160E");
        });

        modelBuilder.Entity<Boleto>(entity =>
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
        });

        modelBuilder.Entity<Categorium>(entity =>
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
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__COMPRA__16C0FA95DCED53D2");

            entity.ToTable("COMPRA");

            entity.HasIndex(e => e.NumeroDocumento, "UQ__COMPRA__87B6EC7E46381EE7").IsUnique();

            entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPRA");
            entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");
            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.IdTransportista).HasColumnName("ID_TRANSPORTISTA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MONTO_TOTAL");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_DOCUMENTO");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .HasColumnName("TIPO_DOCUMENTO");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__COMPRA__ID_PROVE__72C60C4A");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdSucursal)
                .HasConstraintName("FK__COMPRA__ID_SUCUR__71D1E811");

            entity.HasOne(d => d.IdTransportistaNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdTransportista)
                .HasConstraintName("FK__COMPRA__ID_TRANS__73BA3083");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__COMPRA__ID_USUAR__70DDC3D8");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__DETALLE___2E6E01ED018107D7");

            entity.ToTable("DETALLE_COMPRA");

            entity.Property(e => e.IdDetalleCompra).HasColumnName("ID_DETALLE_COMPRA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.PrecioCompra)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO_COMPRA");
            entity.Property(e => e.PrecioVenta)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO_VENTA");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("SUBTOTAL");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK__DETALLE_C__ID_CO__778AC167");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DETALLE_C__ID_PR__787EE5A0");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
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
        });

        modelBuilder.Entity<Funcion>(entity =>
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
        });

        modelBuilder.Entity<Menu>(entity =>
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
        });

        modelBuilder.Entity<Pelicula>(entity =>
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
        });

        modelBuilder.Entity<Permiso>(entity =>
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
        });

        modelBuilder.Entity<Producto>(entity =>
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
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__PROVEEDO__733DB4C436A790F2");

            entity.ToTable("PROVEEDOR");

            entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CEDULA");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_COMPLETO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Reseña>(entity =>
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
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__203B0F68FE33DA3E");

            entity.ToTable("ROL");

            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.IdSala).HasName("PK__SALA__E8F6CE89A8DFBE21");

            entity.ToTable("SALA");

            entity.Property(e => e.IdSala).HasColumnName("ID_SALA");
            entity.Property(e => e.EspacioSala).HasColumnName("ESPACIO_SALA");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__SUCURSAL__AB3873839F4C5670");

            entity.ToTable("SUCURSAL");

            entity.HasIndex(e => e.Codigo, "UQ__SUCURSAL__CC87E126BC653634").IsUnique();

            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CIUDAD");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Ruc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RUC");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Transportistum>(entity =>
        {
            entity.HasKey(e => e.IdTransportista).HasName("PK__TRANSPOR__057F895CC8BF1F8B");

            entity.ToTable("TRANSPORTISTA");

            entity.Property(e => e.IdTransportista).HasColumnName("ID_TRANSPORTISTA");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CEDULA");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Foto).HasColumnName("FOTO");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_COMPLETO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__91136B90DEA15919");

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Clave)
                .HasMaxLength(300)
                .HasColumnName("CLAVE");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_COMPLETO");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__USUARIO__ID_ROL__49C3F6B7");
        });

        modelBuilder.Entity<Ventum>(entity =>
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
