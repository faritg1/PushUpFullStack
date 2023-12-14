using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("producto");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            builder.Property(e => e.Descripcion).HasColumnType("text");
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Precio).HasPrecision(10, 2);
            builder.Property(e => e.StockMax).HasDefaultValueSql("'100'");
            builder.Property(e => e.StockMin).HasDefaultValueSql("'0'");

            builder.HasMany(d => d.IdCategoriaFks).WithMany(p => p.IdProductoFks)
                .UsingEntity<Dictionary<string, object>>(
                    "Productocategorium",
                    r => r.HasOne<Categoria>().WithMany()
                        .HasForeignKey("IdCategoriaFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FkCategoria"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProductoFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FkProducto"),
                    j =>
                    {
                        j.HasKey("IdProductoFk", "IdCategoriaFk")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("productocategoria");
                        j.HasIndex(new[] { "IdCategoriaFk" }, "FkCategoria");
                    });
        }
    }
}