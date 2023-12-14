using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DetalleCarritoConfiguration : IEntityTypeConfiguration<Detallecarrito>
    {
        public void Configure(EntityTypeBuilder<Detallecarrito> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detallecarrito");

            builder.HasIndex(e => e.IdProductoFk, "FKProductoDec");

            builder.HasIndex(e => e.IdCarritoFk, "FkCarrito");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(d => d.IdCarritoFkNavigation).WithMany(p => p.Detallecarritos)
                .HasForeignKey(d => d.IdCarritoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkCarrito");

            builder.HasOne(d => d.IdProductoFkNavigation).WithMany(p => p.Detallecarritos)
                .HasForeignKey(d => d.IdProductoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKProductoDec");
        }
    }
}