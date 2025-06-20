using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class ProductoEtiqueta
{
    public int ProductoId { get; set; }

    public int EtiquetaId { get; set; }

    public bool? Estado { get; set; }

    public virtual Etiqueta Etiqueta { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
