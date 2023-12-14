using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TransaccionConfiguration : IEntityTypeConfiguration<Transaccion>
    {
        public void Configure(EntityTypeBuilder<Transaccion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("transaccion");

            builder.HasIndex(e => e.IdUserFk, "FkUserTrans");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.FechaTransaccion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            builder.Property(e => e.Total).HasPrecision(10, 2);

            builder.HasOne(d => d.IdUserFkNavigation).WithMany(p => p.Transaccions)
                .HasForeignKey(d => d.IdUserFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkUserTrans");
        }
    }
}