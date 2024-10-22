

namespace Kaszanka.Model
{
    public class Request
    {
        internal IRequestsService? requestsService;

        public Request()
        {
        }

        public Request(IRequestsService requestsService) : this()
        {
            this.requestsService = requestsService;
        }

        public string Name { get; set; } = "New request";
        public string Method { get; set; } = "GET";
        public string Url { get; set; } = "www.example.com";
        public List<RequestHeader> Headers { get; set; } = new List<RequestHeader>();

        public string? ResultCode { get; set; } = null;

        public string? ResultContent { get; set; } = null;

        internal async Task Send()
        {
            var result = await requestsService?.Send(this);
            ResultCode = result.resultCode;
            ResultContent = result.resultContent;
        }
    }

    public class RequestHeader
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
