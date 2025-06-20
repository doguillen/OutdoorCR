using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int CategoriaId { get; set; }

    public int Stock { get; set; }

    public decimal? PromedioValoracion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<CarritoDetalle> CarritoDetalle { get; set; } = new List<CarritoDetalle>();

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<ImagenProducto> ImagenProducto { get; set; } = new List<ImagenProducto>();

    public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; } = new List<PedidoDetalle>();

    public virtual ICollection<ProductoEtiqueta> ProductoEtiqueta { get; set; } = new List<ProductoEtiqueta>();

    public virtual ICollection<Promocion> Promocion { get; set; } = new List<Promocion>();

    public virtual ICollection<Resena> Resena { get; set; } = new List<Resena>();
}
