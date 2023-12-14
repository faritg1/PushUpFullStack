using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitofWork
    {
        ICarrito Carritos { get; }
        ICategoria Categorias { get; }
        IDetalleCarrito DetallesCarritos { get; }
        IDetallePedido DetallesPedidos { get; }
        IDetalleTransaccion DetallesTransacciones { get; }
        IFactura Facturas { get; }
        IInventario Inventarios { get; }
        IPedido Pedidos { get; }
        IProducto Productos { get; }
        ITransaccion Transacciones { get; }
        IRefreshToken RefreshTokens {get;}
        IRol Roles {get;}
        IUser Users {get;}
        Task<int> SaveAsync();
    }
}