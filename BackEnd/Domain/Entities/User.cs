using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User : BaseEntity
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
    public ICollection<Rol> Rols { get; set; } = new HashSet<Rol>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public ICollection<UserRol> UsersRols { get; set; }
}
