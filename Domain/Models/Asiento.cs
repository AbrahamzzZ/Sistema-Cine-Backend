using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Asiento
{
    public int IdAsiento { get; set; }

    public int? IdSala { get; set; }

    public string? Fila { get; set; }

    public string? Numero { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Sala? IdSalaNavigation { get; set; }
}
