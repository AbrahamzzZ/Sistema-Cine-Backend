using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class DetalleVentum
{
    public int IdDetalleVenta { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? IdBoleto { get; set; }

    public decimal? PrecioVenta { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Boleto? IdBoletoNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Ventum? IdVentaNavigation { get; set; }
}
