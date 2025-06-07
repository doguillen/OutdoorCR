using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();

    public virtual ICollection<Promocion> Promocion { get; set; } = new List<Promocion>();
}
