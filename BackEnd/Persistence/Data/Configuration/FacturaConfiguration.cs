using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("factura");

            builder.HasIndex(e => e.IdDetalleTransaccionFk, "FkDetaTrans");

            builder.HasIndex(e => e.IdUserFk, "FkUserFac");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.FechaFactura)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            builder.Property(e => e.Total).HasPrecision(10, 2);

            builder.HasOne(d => d.IdDetalleTransaccionFkNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdDetalleTransaccionFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkDetaTrans");

            builder.HasOne(d => d.IdUserFkNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdUserFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkUserFac");
        }
    }
}