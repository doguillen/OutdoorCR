using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class Reseña
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int ProductoId { get; set; }

    public DateTime Fecha { get; set; }

    public string? Comentario { get; set; }

    public int? Valoracion { get; set; }

    public bool? Visible { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
