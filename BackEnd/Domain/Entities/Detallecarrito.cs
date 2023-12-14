using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Detallecarrito : BaseEntity
{
    public int IdCarritoFk { get; set; }

    public int IdProductoFk { get; set; }

    public int Cantidad { get; set; }

    public virtual Carrito IdCarritoFkNavigation { get; set; }

    public virtual Producto IdProductoFkNavigation { get; set; }
}
