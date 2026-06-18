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
        private readonly DataContext Context;
        public IGenericReposotiry<PortfolioItem> PortfolioItems { get; }
        public IOwnerReposotiry SpecificOwners { get; }


        public UnitOfWork(DataContext context
            , IGenericReposotiry<PortfolioItem> PortfolioItem,
            IOwnerReposotiry SpecificOwners)
        {
            this.Context = context;
            this.PortfolioItems = PortfolioItem;
            this.SpecificOwners = SpecificOwners;
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
