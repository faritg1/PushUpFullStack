using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DetalleTransaccionConfiguration : IEntityTypeConfiguration<Detalletransaccion>
    {
        public void Configure(EntityTypeBuilder<Detalletransaccion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detalletransaccion");

            builder.HasIndex(e => e.IdProductoFk, "FKProductoDeTrans");

            builder.HasIndex(e => e.IdTransaccionFk, "FkTransacionDe");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.PrecioUnitario).HasPrecision(10, 2);

            builder.HasOne(d => d.IdProductoFkNavigation).WithMany(p => p.Detalletransaccions)
                .HasForeignKey(d => d.IdProductoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKProductoDeTrans");

            builder.HasOne(d => d.IdTransaccionFkNavigation).WithMany(p => p.Detalletransaccions)
                .HasForeignKey(d => d.IdTransaccionFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkTransacionDe");
        }
    }
}