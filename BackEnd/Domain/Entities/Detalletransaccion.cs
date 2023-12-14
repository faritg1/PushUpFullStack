using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Detalletransaccion : BaseEntity
{
    public int IdTransaccionFk { get; set; }

    public int IdProductoFk { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Producto IdProductoFkNavigation { get; set; }

    public virtual Transaccion IdTransaccionFkNavigation { get; set; }
}
