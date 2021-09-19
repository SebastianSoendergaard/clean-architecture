using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.User.UseCases.AddUser;
using CleanArchitecture.Infrastructure.Storage.File.Common;

namespace CleanArchitecture.Infrastructure.Storage.File.User.UseCases.AddUser
{
    public class AddUserRepository : AbstractRepository, AddUserUseCase.IRepository
    {
        private readonly StorageLocationResolver locationResolver;

        public AddUserRepository(StorageLocationResolver locationResolver)
        {
            this.locationResolver = locationResolver;
        }

        public Task CreateUserAsync(Guid id, string name)
        {
            var user = new UserEntity { Id = id, Name = name };
            return SaveToFile(id, locationResolver.UserPath, user);
        }
    }
}
