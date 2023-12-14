using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Transaccion : BaseEntity
{
    public int IdUserFk { get; set; }

    public DateTime? FechaTransaccion { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<Detalletransaccion> Detalletransaccions { get; set; } = new List<Detalletransaccion>();

    public virtual User IdUserFkNavigation { get; set; }
}
