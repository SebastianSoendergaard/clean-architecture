using CleanArchitecture.Application.User.UseCases.AddUser;
using CleanArchitecture.Infrastructure.Storage.File.User.UseCases.AddUser;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Storage.File
{
    public static class Dependencies
    {
        public static IServiceCollection AddFileStorage(this IServiceCollection services, string dataPath)
        {
            services.AddSingleton(new StorageLocation { Path = dataPath }); 
            services.AddScoped<StorageLocationResolver>();
            services.AddScoped<AddUserUseCase.IRepository, AddUserRepository>();
            return services;
        }
    }
}
