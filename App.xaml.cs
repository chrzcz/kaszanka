using Kaszanka.ViewModels;
using Kaszanka.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Kaszanka
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            Current.MainWindow = new MainWindow(serviceProvider.GetRequiredService<MainWindowViewModel>());
            Current.MainWindow.Show();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }

}
