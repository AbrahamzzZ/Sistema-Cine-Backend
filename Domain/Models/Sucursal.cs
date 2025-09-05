using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Ruc { get; set; }

    public string? Telefono { get; set; }

    public string? Ciudad { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
