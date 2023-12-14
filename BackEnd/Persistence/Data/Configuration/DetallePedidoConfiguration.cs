using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<Detallepedido>
    {
        public void Configure(EntityTypeBuilder<Detallepedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detallepedido");

            builder.HasIndex(e => e.IdPedidoFk, "FkPedido");

            builder.HasIndex(e => e.IdProductoFk, "FkProductoDe");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.PrecioUnitario).HasPrecision(10, 2);

            builder.HasOne(d => d.IdPedidoFkNavigation).WithMany(p => p.Detallepedidos)
                .HasForeignKey(d => d.IdPedidoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkPedido");

            builder.HasOne(d => d.IdProductoFkNavigation).WithMany(p => p.Detallepedidos)
                .HasForeignKey(d => d.IdProductoFk)
                .HasConstraintName("FkProductoDe");
        }
    }
}