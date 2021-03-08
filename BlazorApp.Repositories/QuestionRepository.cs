using BlazorApp.Context;
using BlazorApp.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Repositories
{
    public class QuestionRepository : Implementation.IQuestionRepository
    {
        private readonly BlazorAppDbContext _context;

        public QuestionRepository(BlazorAppDbContext context)
        {
            _context = context;
        }

        public DbSet<Question> Entity => _context.Questions;

        public async Task<int> Delete(int id)
        {
            var entity = await Entity.FindAsync(id);
            Entity.Remove(entity);
            return id;
        }

        public async Task<IEnumerable<Question>> Get()
        {
            return await Entity.ToListAsync();
        }

        public async Task<Question> Get(int id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<int> Post(Question entity)
        {
            await Entity.AddAsync(entity);
            return entity.Id;
        }

        public async Task<int> Put(Question entity)
        {
            var entry = await Entity.FindAsync(entity.Id);
            _context.Entry(entry).CurrentValues.SetValues(entity);
            return entry.Id;
        }
    }
}
