using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IGenericReposotiry<Owner> Owners { get; }
        public IGenericReposotiry<PortfolioItem> PortfolioItems { get; }

        public IOwnerReposotiry SpecificOwners { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Owners = new GenericRepository<Owner>(_context);
            PortfolioItems = new GenericRepository<PortfolioItem>(_context);
            SpecificOwners = new OwnerRepository(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
