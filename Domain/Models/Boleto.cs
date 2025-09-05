using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Boleto
{
    public int IdBoleto { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdFuncion { get; set; }

    public int? IdAsiento { get; set; }

    public DateTime? FechaCompra { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Asiento? IdAsientoNavigation { get; set; }

    public virtual Funcion? IdFuncionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
