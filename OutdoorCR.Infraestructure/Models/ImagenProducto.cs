﻿using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class ImagenProducto
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public byte[] Imagen { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
