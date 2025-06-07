using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class Carrito
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<CarritoDetalle> CarritoDetalle { get; set; } = new List<CarritoDetalle>();

    public virtual Usuario Usuario { get; set; } = null!;
}
