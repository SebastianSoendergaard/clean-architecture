using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IMediator, Mediator>();
            services.AddMediatR(typeof(Dependencies).Assembly);
            return services;
        }
    }
}
