using BlazorApp.Context;
using BlazorApp.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Repositories
{
    public class ResultRepository : Implementation.IResultRepository
    {
        private readonly BlazorAppDbContext _context;

        public ResultRepository(BlazorAppDbContext context)
        {
            _context = context;
        }

        public DbSet<Result> Entity => _context.Results;

        public async Task<int> Delete(int id)
        {
            var entity = await Entity.FindAsync(id);
            Entity.Remove(entity);
            return id;
        }

        public async Task<IEnumerable<Result>> Get()
        {
            return await Entity.ToListAsync();
        }

        public async Task<Result> Get(int id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<int> Post(Result entity)
        {
            await Entity.AddAsync(entity);
            return entity.Id;
        }

        public async Task<int> Put(Result entity)
        {
            var entry = await Entity.FindAsync(entity.Id);
            _context.Entry(entry).CurrentValues.SetValues(entity);
            return entry.Id;
        }
    }
}
