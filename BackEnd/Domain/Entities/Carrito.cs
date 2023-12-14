using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Carrito : BaseEntity
{

    public int IdUserFk { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Detallecarrito> Detallecarritos { get; set; } = new List<Detallecarrito>();

    public virtual User IdUserFkNavigation { get; set; }
}
