using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("pedido");

            builder.HasIndex(e => e.IdUserFk, "FkUser");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(d => d.IdUserFkNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdUserFk)
                .HasConstraintName("FkUser");
        }
    }
}