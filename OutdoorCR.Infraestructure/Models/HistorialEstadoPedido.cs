using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class HistorialEstadoPedido
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public int EstadoId { get; set; }

    public DateTime? FechaCambio { get; set; }

    public virtual EstadoPedido Estado { get; set; } = null!;

    public virtual Pedido Pedido { get; set; } = null!;
}
