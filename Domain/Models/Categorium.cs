using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? Codigo { get; set; }

    public string? NombreCategoria { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
