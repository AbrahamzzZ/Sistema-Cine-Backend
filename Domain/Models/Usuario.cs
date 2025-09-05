using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Clave { get; set; }

    public int? IdRol { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
