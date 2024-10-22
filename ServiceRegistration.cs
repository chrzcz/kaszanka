using Kaszanka.Helpers;
using Kaszanka.Model;
using Kaszanka.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Kaszanka
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<MainWindowViewModel>();
            serviceCollection.AddSingleton<IRequestsService, RequestsService>();
            serviceCollection.AddSingleton<IRequestViewModelFactory, RequestViewModelFactory>();
            serviceCollection.AddSingleton<IRequestValidator, RequestValidator>();
            serviceCollection.AddSingleton<ICommonFileDialogHelper, CommonFileDialogHelper>();
            serviceCollection.AddSingleton<IFileHelper, FileHelper>();
            serviceCollection.AddSingleton(new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
