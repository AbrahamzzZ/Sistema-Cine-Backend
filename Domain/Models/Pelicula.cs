using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public byte[]? Poster { get; set; }

    public string? NombrePelicula { get; set; }

    public string? GeneroPelicula { get; set; }

    public int? Duracion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Funcion> Funcions { get; set; } = new List<Funcion>();

    public virtual ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();
}
