using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Reseña
{
    public int IdResenia { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdPelicula { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Pelicula? IdPeliculaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
