using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("carrito");

            builder.HasIndex(e => e.IdUserFk, "FkUserCar");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");

            builder.HasOne(d => d.IdUserFkNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.IdUserFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkUserCar");
        }
    }
}