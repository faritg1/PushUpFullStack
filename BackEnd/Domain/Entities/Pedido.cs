using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pedido : BaseEntity
{
    public int? IdUserFk { get; set; }

    public DateOnly Fecha { get; set; }

    public string Estado { get; set; }

    public virtual ICollection<Detallepedido> Detallepedidos { get; set; } = new List<Detallepedido>();

    public virtual User IdUserFkNavigation { get; set; }
}
