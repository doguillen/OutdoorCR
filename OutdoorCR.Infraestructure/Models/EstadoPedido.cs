using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class EstadoPedido
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<HistorialEstadoPedido> HistorialEstadoPedido { get; set; } = new List<HistorialEstadoPedido>();
}
