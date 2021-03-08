using BlazorApp.Repositories;
using BlazorApp.Repositories.Implementation;
using BlazorApp.Services;
using BlazorApp.UnitOfWork.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp.Server
{
    public static class BlazorAppServiceCollections
    {
        public static IServiceCollection AddBlazorAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
            services.AddScoped<ObjectiveService>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<QuestionService>();

            services.AddScoped<IRespondentRepository, RespondentRepository>();
            services.AddScoped<RespondentService>();

            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<ResultService>();

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
