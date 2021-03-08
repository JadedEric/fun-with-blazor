using BlazorApp.Context;
using BlazorApp.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Repositories
{
    public class ObjectiveRepository : Implementation.IObjectiveRepository
    {
        private readonly BlazorAppDbContext _context;

        public ObjectiveRepository(BlazorAppDbContext context)
        {
            _context = context;
        }

        public DbSet<Objective> Entity => _context.Objectives;

        public async Task<int> Delete(int id)
        {
            var entity = await Entity.FindAsync(id);
            Entity.Remove(entity);
            return id;
        }

        public async Task<IEnumerable<Objective>> Get()
        {
            return await Entity.ToListAsync();
        }

        public async Task<Objective> Get(int id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<int> Post(Objective entity)
        {
            await Entity.AddAsync(entity);
            return entity.Id;
        }

        public async Task<int> Put(Objective entity)
        {
            var entry = await Entity.FindAsync(entity.Id);
            _context.Entry(entry).CurrentValues.SetValues(entity);
            return entry.Id;
        }
    }
}
