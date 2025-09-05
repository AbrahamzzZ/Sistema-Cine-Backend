using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Codigo { get; set; }

    public string? NombreProducto { get; set; }

    public int? IdCategoria { get; set; }

    public int Stock { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public string? Tipo { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Categorium? IdCategoriaNavigation { get; set; }
}
