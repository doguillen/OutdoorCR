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

    public virtual DbSet<ProductoEtiqueta> ProductoEtiqueta { get; set; }

    public virtual DbSet<Promocion> Promocion { get; set; }

    public virtual DbSet<Resena> Resena { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrito__3214EC07139BF60A");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Carrito)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carrito__Usuario__47DBAE45");
        });

        modelBuilder.Entity<CarritoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarritoD__3214EC078FD697E4");

            entity.HasOne(d => d.Carrito).WithMany(p => p.CarritoDetalle)
                .HasForeignKey(d => d.CarritoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoDe__Carri__4AB81AF0");

            entity.HasOne(d => d.Producto).WithMany(p => p.CarritoDetalle)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoDe__Produ__4BAC3F29");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07D558C619");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<EstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstadoPe__3214EC075E74AF48");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Etiqueta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Etiqueta__3214EC07B4D88542");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<HistorialEstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC07E75D9AE5");

            entity.Property(e => e.FechaCambio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Estado).WithMany(p => p.HistorialEstadoPedido)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__Estad__5AEE82B9");

            entity.HasOne(d => d.Pedido).WithMany(p => p.HistorialEstadoPedido)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__Pedid__59FA5E80");
        });

        modelBuilder.Entity<ImagenProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImagenPr__3214EC07B9C826A1");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.Producto).WithMany(p => p.ImagenProducto)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImagenPro__Produ__31EC6D26");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido__3214EC0719CF1FAB");

            entity.Property(e => e.DireccionEnvio).HasMaxLength(255);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedido)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__UsuarioI__5070F446");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PedidoDe__3214EC073ADDC7C0");

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoDet__Pedid__534D60F1");

            entity.HasOne(d => d.Producto).WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoDet__Produ__5441852A");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC079C1E1815");

            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PromedioValoracion)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Producto)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__Catego__2E1BDC42");
        });

        modelBuilder.Entity<ProductoEtiqueta>(entity =>
        {
            entity.HasKey(e => new { e.ProductoId, e.EtiquetaId }).HasName("PK__Producto__87F69922CEDEED19");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.Etiqueta).WithMany(p => p.ProductoEtiqueta)
                .HasForeignKey(d => d.EtiquetaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductoE__Etiqu__38996AB5");

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductoEtiqueta)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductoE__Produ__37A5467C");
        });

        modelBuilder.Entity<Promocion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocio__3214EC07A603E0A0");

            entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Tipo).HasMaxLength(20);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Promocion)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Promocion__Categ__440B1D61");

            entity.HasOne(d => d.Producto).WithMany(p => p.Promocion)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Promocion__Produ__4316F928");
        });

        modelBuilder.Entity<Resena>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resena__3214EC0752312897");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Producto).WithMany(p => p.Resena)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resena__Producto__3F466844");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Resena)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resena__UsuarioI__3E52440B");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC076A6A94AC");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07362F3D0F");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuario__531402F36668F78B").IsUnique();

            entity.Property(e => e.ContrasenaHash).HasMaxLength(255);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.NombreUsuario).HasMaxLength(100);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__Estado__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
