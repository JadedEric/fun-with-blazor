using BlazorApp.Repositories.Implementation;
using System;
using System.Threading.Tasks;

namespace BlazorApp.UnitOfWork.Implementation
{
    public interface IUnitOfWork: IDisposable
    {
        IObjectiveRepository Objectives { get; set; }

        IQuestionRepository Questions { get; set; }

        IRespondentRepository Respondents { get; set; }

        IResultRepository Results { get; set; }

        Task<int> CompleteAsync();
    }
}
