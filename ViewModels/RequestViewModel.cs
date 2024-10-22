using Kaszanka.Model;

namespace Kaszanka.ViewModels
{
    public class RequestViewModel : NotifyBase
    {
        public RequestViewModel(Request request, IRequestValidator requestValidator)
        {
            this.request = request;
            this.requestValidator = requestValidator;
        }

        public readonly Request request;
        private readonly IRequestValidator requestValidator;

        public string Name
        {
            get => request.Name;
            set
            {
                request.Name = value;
                Notify(this, x => x.Name);
            }
        }

        public string Method
        {
            get => request.Method;
            set
            {
                request.Method = value;
                Notify(this, x => x.Method);
            }
        }

        public string Url
        {
            get => request.Url;
            set
            {
                request.Url = value;
                Notify(this, x => x.Url);
            }
        }

        public List<RequestHeader> Headers
        {
            get => request.Headers;
            set
            {
                request.Headers = value;
                Notify(this, x => x.Headers);
            }
        }

        public string StatusCode
        {
            get => request.ResultCode ?? string.Empty;
        }

        public string ResultContent
        {
            get => request.ResultContent ?? string.Empty;
        }

        public SimpleAsyncCommand Send => new SimpleAsyncCommand(async () => {
            await request.Send();
            Notify(this, x => x.StatusCode);
            Notify(this, x => x.ResultContent);
           } , () => requestValidator.ValidateUrl(Url));

        public static IEnumerable<string> Methods => ["GET", "POST", "PUT", "DELTE", "PATCH", "HEAD", "CONNECT", "OPTIONS", "TRACE"];
    }
}
