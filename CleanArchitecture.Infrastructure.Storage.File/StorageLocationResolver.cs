using System.IO;

namespace CleanArchitecture.Infrastructure.Storage.File
{
    public class StorageLocation
    { 
        public string Path { get; init; }
    }

    public class StorageLocationResolver
    {
        private readonly StorageLocation location;

        public StorageLocationResolver(StorageLocation location)
        {
            this.location = location;
        }

        public string UserPath => Path.Combine(location.Path, "users");
    }
}
