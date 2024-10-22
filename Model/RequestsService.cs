using System.Net.Http;
using System.Text.Json;

namespace Kaszanka.Model
{
    class RequestsService : IRequestsService
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public RequestsService(JsonSerializerOptions jsonSerializerOptions)
        {
            this.jsonSerializerOptions = jsonSerializerOptions;
        }

        public IEnumerable<Request> ReadRequests(string collectionJson)
        {
            return JsonSerializer.Deserialize<IEnumerable<Request>>(collectionJson) ?? [];
        }

        public string SaveRequests(IEnumerable<Request> colleciton)
        {
            return JsonSerializer.Serialize(colleciton);
        }

        public async Task<(string resultCode, string? resultContent)> Send(Request request)
        {
            var uriBuilder = new UriBuilder(request.Url);
            
            using HttpClient client = new();
            using HttpRequestMessage message = new(HttpMethod.Parse(request.Method), uriBuilder.Uri);

            AddHeaders(message, request.Headers);

            var result = await client.SendAsync(message);

            return ($"{(int)result.StatusCode} {result.StatusCode.ToString()}", await result.Content.ReadAsStringAsync());
        }

        private void AddHeaders(HttpRequestMessage message, List<RequestHeader> headers)
        {
            foreach(var header in headers)
            {
                message.Headers.Add(header.Name, header.Value);
            }
        }
    }
}
