using BlazorApp.Domains;
using BlazorApp.Shared;

namespace BlazorApp.Server
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<Objective, ObjectiveViewModel>();
            CreateMap<Question, QuestionViewModel>();
            CreateMap<Respondent, RespondentViewModel>();
            CreateMap<Result, ResultViewModel>();

            CreateMap<ObjectiveViewModel, Objective>();
            CreateMap<QuestionViewModel, Question>();
            CreateMap<RespondentViewModel, Respondent>();
            CreateMap<ResultViewModel, Result>();
        }
    }
}
