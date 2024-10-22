using Kaszanka.Helpers;
using Kaszanka.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace Kaszanka.ViewModels
{
    public class MainWindowViewModel : NotifyBase
    {
        private readonly IRequestViewModelFactory requestVmFactory;
        private readonly ICommonFileDialogHelper dialogHelper;
        private readonly IRequestsService requestsService;
        private readonly IFileHelper fileHelper;

        public MainWindowViewModel(
            IRequestViewModelFactory requestVmFactory, 
            ICommonFileDialogHelper dialogHelper, 
            IRequestsService requestsService,
            IFileHelper fileHelper)
        {
            this.requestVmFactory = requestVmFactory;
            this.dialogHelper = dialogHelper;
            this.requestsService = requestsService;
            this.fileHelper = fileHelper;
        }

        public BindingList<RequestViewModel> Requests { get; set; } = new BindingList<RequestViewModel>();

        public ICommand AddNewRequest => new SimpleCommand(() => {
            Requests.Add(requestVmFactory?.Build() ?? throw new ArgumentNullException("Request factory is null")); 
        }, () => true);

        public ICommand SaveRequests => new SimpleAsyncCommand(async () =>
        {
            var path = dialogHelper.GetSaveFilePath();
            if(!string.IsNullOrWhiteSpace(path))
            {
                var content = requestsService.SaveRequests(Requests.Select(r => r.request).ToList());
                await fileHelper.SaveFile(path, content);
            }
        }, () => true);

        public ICommand ReadRequests => new SimpleAsyncCommand(async () =>
        {
            var path = dialogHelper.GetReadFilePath();
            if(!string.IsNullOrWhiteSpace(path))
            {
                var content = await fileHelper.ReadFile(path);
                var requests = requestsService.ReadRequests(content);
                Requests.Clear();
                foreach(var request in requests)
                {
                    Requests.Add(requestVmFactory.BuildFromRequest(request));
                }
            }
        }, () => true);
    }
}
