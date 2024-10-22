namespace Kaszanka.Helpers
{
    public interface IFileHelper
    {
        public Task SaveFile(string path, string content);
        public Task<string> ReadFile(string path);
    }
}
