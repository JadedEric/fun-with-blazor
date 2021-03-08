using BlazorApp.Context;
using BlazorApp.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Repositories
{
    public class RespondentRepository : Implementation.IRespondentRepository
    {
        private readonly BlazorAppDbContext _context;

        public RespondentRepository(BlazorAppDbContext context)
        {
            _context = context;
        }

        public DbSet<Respondent> Entity => _context.Respondents;

        public async Task<int> Delete(int id)
        {
            var entity = await Entity.FindAsync(id);
            Entity.Remove(entity);
            return id;
        }

        public async Task<IEnumerable<Respondent>> Get()
        {
            return await Entity.ToListAsync();
        }

        public async Task<Respondent> Get(int id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<int> Post(Respondent entity)
        {
            await Entity.AddAsync(entity);
            return entity.Id;
        }

        public async Task<int> Put(Respondent entity)
        {
            var entry = await Entity.FindAsync(entity.Id);
            _context.Entry(entry).CurrentValues.SetValues(entity);
            return entry.Id;
        }
    }
}
