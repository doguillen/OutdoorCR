using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class Etiqueta
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<ProductoEtiqueta> ProductoEtiqueta { get; set; } = new List<ProductoEtiqueta>();
}
