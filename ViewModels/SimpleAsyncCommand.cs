
using System.Windows.Input;

namespace Kaszanka.ViewModels
{
    public class SimpleAsyncCommand : ICommand
    {
        private readonly Func<object?, Task> commandLogic;
        private readonly Func<object?, bool> commandGuard;
        
        public event EventHandler? CanExecuteChanged;

        public void NotifyCommand()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public SimpleAsyncCommand(Func<Task> commandLogic, Func<bool> commandGuard)
        {
            this.commandLogic = (_) => commandLogic();
            this.commandGuard = (_) => commandGuard();
        }

        public bool CanExecute(object? parameter)
        {
            return commandGuard(parameter);
        }

        public async void Execute(object? parameter)
        {
            await commandLogic(parameter);
        }
    }
}
