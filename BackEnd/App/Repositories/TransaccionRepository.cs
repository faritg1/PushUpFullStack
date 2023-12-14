using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace App.Repositories
{
    public class TransaccionRepository : GenericRepository<Transaccion>, ITransaccion
    {
        private readonly NikeContext _context;

        public TransaccionRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }
}