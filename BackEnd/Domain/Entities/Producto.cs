using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Producto : BaseEntity
{
    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Existencia { get; set; }

    public int? StockMin { get; set; }

    public int? StockMax { get; set; }

    public virtual ICollection<Detallecarrito> Detallecarritos { get; set; } = new List<Detallecarrito>();

    public virtual ICollection<Detallepedido> Detallepedidos { get; set; } = new List<Detallepedido>();

    public virtual ICollection<Detalletransaccion> Detalletransaccions { get; set; } = new List<Detalletransaccion>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Categoria> IdCategoriaFks { get; set; } = new List<Categoria>();
}
