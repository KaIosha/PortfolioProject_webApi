using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerReposotiry
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Owner?> GetOwnerWithDetailsAsync(Guid id)
        {
            return await _context.Owners
                .Include(o => o.Address)
                .Include(o => o.PortfolioItems)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
