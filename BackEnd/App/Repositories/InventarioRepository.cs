using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace App.Repositories
{
    public class InventarioRepository : GenericRepository<Inventario>, IInventario
    {
        private readonly NikeContext _context;

        public InventarioRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }
}