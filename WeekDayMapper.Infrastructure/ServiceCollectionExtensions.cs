using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeekDayMapper.Application.Repositories;
using WeekDayMapper.Infrastructure.Authentication;
using WeekDayMapper.Infrastructure.Repositories;

namespace WeekDayMapper.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IClassARepository, ClassARepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();

            return services;
        }
    }
}
