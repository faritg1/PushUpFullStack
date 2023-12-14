using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace App.Repositories
{
    public class CarritoRepository : GenericRepository<Carrito>, ICarrito
    {
        private readonly NikeContext _context;

        public CarritoRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }

}