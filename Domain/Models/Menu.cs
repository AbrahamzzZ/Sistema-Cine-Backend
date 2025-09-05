using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Nombre { get; set; }

    public string? UrlMenu { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
