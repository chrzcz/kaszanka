using System.ComponentModel;

namespace Kaszanka.Model
{
    public interface IRequestsService
    {
        public IEnumerable<Request> ReadRequests(string collectionJson);
        public string SaveRequests(IEnumerable<Request> colleciton);
        Task<(string resultCode, string? resultContent)> Send(Request request);
    }
}
