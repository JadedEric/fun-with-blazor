using BlazorApp.Context;
using BlazorApp.Repositories.Implementation;
using BlazorApp.UnitOfWork.Implementation;
using System;
using System.Threading.Tasks;

namespace BlazorApp.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IObjectiveRepository Objectives { get; set; }
        
        public IQuestionRepository Questions { get; set; }
        
        public IRespondentRepository Respondents { get; set; }
        
        public IResultRepository Results { get; set; }

        private readonly BlazorAppDbContext _context;

        public UnitOfWork(
            BlazorAppDbContext context,
            IObjectiveRepository objectiveRepository,
            IQuestionRepository questionRepository,
            IRespondentRepository respondentRepository,
            IResultRepository resultRepository)
        {
            _context = context;
            Objectives = objectiveRepository;
            Questions = questionRepository;
            Respondents = respondentRepository;
            Results = resultRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
