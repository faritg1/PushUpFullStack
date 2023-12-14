using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Detallepedido : BaseEntity
{
    public int IdPedidoFk { get; set; }

    public int? IdProductoFk { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Pedido IdPedidoFkNavigation { get; set; }

    public virtual Producto IdProductoFkNavigation { get; set; }
}
