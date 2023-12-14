using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Categoria : BaseEntity
{
    public string Nombre { get; set; }

    public virtual ICollection<Producto> IdProductoFks { get; set; } = new List<Producto>();
}
