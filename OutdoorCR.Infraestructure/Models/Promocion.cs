using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class Promocion
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public int? ProductoId { get; set; }

    public int? CategoriaId { get; set; }

    public decimal Descuento { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual Producto? Producto { get; set; }
}
