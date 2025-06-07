using System;
using System.Collections.Generic;

namespace OutdoorCR.Infraestructure.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string ContrasenaHash { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int RolId { get; set; }

    public virtual ICollection<Carrito> Carrito { get; set; } = new List<Carrito>();

    public virtual ICollection<Pedido> Pedido { get; set; } = new List<Pedido>();

    public virtual ICollection<Reseña> Reseña { get; set; } = new List<Reseña>();

    public virtual Rol Rol { get; set; } = null!;
}
