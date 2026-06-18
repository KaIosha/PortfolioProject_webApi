using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericReposotiry<T> where T : class
    {
        private readonly DataContext _contex;
        private DbSet<T> table;
        public GenericRepository(DataContext context)
        {
            _contex = context;
            table = _contex.Set<T>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await GetByIdAsync(id);

            if (item != null)
                table.Remove(item);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await table.FindAsync(id);
        }

        public async Task InsertAsync(T Entity)
        {
            await table.AddAsync(Entity);
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }
    }
}
