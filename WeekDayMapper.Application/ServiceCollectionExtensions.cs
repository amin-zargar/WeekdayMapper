using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeekDayMapper.Application.UseCases.Classes;
using WeekDayMapper.Application.UseCases.Members;
using FluentValidation;
using MediatR;
using WeekDayMapper.Application.PipelineBehaviors;
using WeekDayMapper.Application.Interfaces;

namespace WeekDayMapper.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining<CreateClassACommand>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<LoginCommand>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<IJwtProvider>(ServiceLifetime.Transient);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
