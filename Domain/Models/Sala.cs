using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Sala
{
    public int IdSala { get; set; }

    public string? Tipo { get; set; }

    public int? EspacioSala { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();

    public virtual ICollection<Funcion> Funcions { get; set; } = new List<Funcion>();
}
