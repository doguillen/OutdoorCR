using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OutdoorCR.Infraestructure.Models;

namespace OutdoorCR.Infraestructure.Data;

public partial class OutdoorCRContext : DbContext
{
    public OutdoorCRContext(DbContextOptions<OutdoorCRContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carrito { get; set; }

    public virtual DbSet<CarritoDetalle> CarritoDetalle { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<EstadoPedido> EstadoPedido { get; set; }

    public virtual DbSet<Etiqueta> Etiqueta { get; set; }

    public virtual DbSet<HistorialEstadoPedido> HistorialEstadoPedido { get; set; }

    public virtual DbSet<ImagenProducto> ImagenProducto { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalle { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Promocion> Promocion { get; set; }

    public virtual DbSet<Reseña> Reseña { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrito__3214EC07370F606B");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Carrito)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carrito__Usuario__45F365D3");
        });

        modelBuilder.Entity<CarritoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarritoD__3214EC07391BA42B");

            entity.HasOne(d => d.Carrito).WithMany(p => p.CarritoDetalle)
                .HasForeignKey(d => d.CarritoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoDe__Carri__48CFD27E");

            entity.HasOne(d => d.Producto).WithMany(p => p.CarritoDetalle)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoDe__Produ__49C3F6B7");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07522B8E56");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<EstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstadoPe__3214EC07DB3DF3D4");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Etiqueta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Etiqueta__3214EC077DF3D25F");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<HistorialEstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC07A5E318E5");

            entity.Property(e => e.FechaCambio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Estado).WithMany(p => p.HistorialEstadoPedido)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__Estad__5812160E");

            entity.HasOne(d => d.Pedido).WithMany(p => p.HistorialEstadoPedido)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__Pedid__571DF1D5");
        });

        modelBuilder.Entity<ImagenProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImagenPr__3214EC07CCDD0D9F");

            entity.Property(e => e.UrlImagen).HasMaxLength(255);

            entity.HasOne(d => d.Producto).WithMany(p => p.ImagenProducto)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImagenPro__Produ__30F848ED");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido__3214EC07E6062578");

            entity.Property(e => e.DireccionEnvio).HasMaxLength(255);
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedido)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__UsuarioI__4D94879B");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PedidoDe__3214EC07745908FE");

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoDet__Pedid__5070F446");

            entity.HasOne(d => d.Producto).WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoDet__Produ__5165187F");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07DE57E03C");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PromedioValoracion)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Producto)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__Catego__2E1BDC42");

            entity.HasMany(d => d.Etiqueta).WithMany(p => p.Producto)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductoEtiqueta",
                    r => r.HasOne<Etiqueta>().WithMany()
                        .HasForeignKey("EtiquetaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductoE__Etiqu__36B12243"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductoE__Produ__35BCFE0A"),
                    j =>
                    {
                        j.HasKey("ProductoId", "EtiquetaId").HasName("PK__Producto__87F6992208205997");
                    });
        });

        modelBuilder.Entity<Promocion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocio__3214EC078A80CA53");

            entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Tipo).HasMaxLength(20);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Promocion)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Promocion__Categ__4222D4EF");

            entity.HasOne(d => d.Producto).WithMany(p => p.Promocion)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Promocion__Produ__412EB0B6");
        });

        modelBuilder.Entity<Reseña>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reseña__3214EC07B6E39BAB");

            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Visible).HasDefaultValue(true);

            entity.HasOne(d => d.Producto).WithMany(p => p.Reseña)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reseña__Producto__3D5E1FD2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reseña)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reseña__UsuarioI__3C69FB99");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC0755A84BA0");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC0780979792");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuario__531402F33AF6F504").IsUnique();

            entity.Property(e => e.ContrasenaHash).HasMaxLength(255);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.NombreUsuario).HasMaxLength(100);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__RolId__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
