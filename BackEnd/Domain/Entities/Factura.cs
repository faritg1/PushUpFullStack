using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Factura : BaseEntity
{
    public int IdUserFk { get; set; }

    public int IdDetalleTransaccionFk { get; set; }

    public DateTime? FechaFactura { get; set; }

    public decimal Total { get; set; }

    public virtual Detalletransaccion IdDetalleTransaccionFkNavigation { get; set; }

    public virtual User IdUserFkNavigation { get; set; }
}
