using Kaszanka.Model;

namespace Kaszanka.ViewModels
{
    public class RequestViewModelFactory : IRequestViewModelFactory
    {
        private readonly IRequestsService requestsService;
        private readonly IRequestValidator requestValidator;

        public RequestViewModelFactory(IRequestsService requestsService, IRequestValidator requestValidator)
        {
            this.requestsService = requestsService;
            this.requestValidator = requestValidator;
        }

        public RequestViewModel Build()
        {
            return new RequestViewModel(new Request(requestsService), requestValidator);
        }

        public RequestViewModel BuildFromRequest(Request request)
        {
            request.requestsService = requestsService;
            return new RequestViewModel(request, requestValidator);
        }
    }
}
