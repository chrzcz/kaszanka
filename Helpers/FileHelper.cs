using System.IO;

namespace Kaszanka.Helpers
{
    public class FileHelper : IFileHelper
    {
        public async Task<string> ReadFile(string path)
        {
            using var reader = new StreamReader(path);
            return await reader.ReadToEndAsync();
        }

        public async Task SaveFile(string path, string content)
        {
            using var writer = new StreamWriter(path);
            await writer.WriteAsync(content);
        }
    }
}
