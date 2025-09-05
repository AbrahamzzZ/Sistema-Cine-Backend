using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Cedula { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
