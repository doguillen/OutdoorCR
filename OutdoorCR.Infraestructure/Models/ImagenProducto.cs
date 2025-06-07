using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class ImagenProducto
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public string UrlImagen { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
