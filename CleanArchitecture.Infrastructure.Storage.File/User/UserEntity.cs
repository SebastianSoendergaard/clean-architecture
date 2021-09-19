using System;

namespace CleanArchitecture.Infrastructure.Storage.File.User
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
