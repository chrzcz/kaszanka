using Kaszanka.Model;

namespace Kaszanka.ViewModels
{
    public interface IRequestViewModelFactory
    {
        RequestViewModel Build();
        RequestViewModel BuildFromRequest(Request request);
    }
}
