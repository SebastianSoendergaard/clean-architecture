using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Storage.File.Common
{
    public class AbstractRepository
    {
        protected Task SaveToFile<Tobject>(Guid id, string path, Tobject obj)
        {
            var data = Serialize(obj);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var file = Path.Combine(path, id.ToString() + ".json");

            return System.IO.File.WriteAllBytesAsync(file, data);
        }

        protected async Task<Tobject> LoadFromFile<Tobject>(Guid id, string path)
        {
            var file = Path.Combine(path, id.ToString() + ".json");

            if (System.IO.File.Exists(file))
            {
                var data = await System.IO.File.ReadAllBytesAsync(file);
                return Deserialize<Tobject>(data);
            }

            return default;
        }

        private byte[] Serialize<Tobject>(Tobject obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes(obj);
        }

        private Tobject Deserialize<Tobject>(byte[] data)
        {
            return JsonSerializer.Deserialize<Tobject>(new System.ReadOnlySpan<byte>(data));
        }
    }
}
