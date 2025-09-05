using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Funcion
{
    public int IdFuncion { get; set; }

    public int? IdPelicula { get; set; }

    public int? IdSala { get; set; }

    public DateTime? FechaHoraInicio { get; set; }

    public DateTime? FechaHoraFin { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Pelicula? IdPeliculaNavigation { get; set; }

    public virtual Sala? IdSalaNavigation { get; set; }
}
