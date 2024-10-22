
using System.Windows.Input;

namespace Kaszanka.ViewModels
{
    public class SimpleCommand : ICommand
    {
        private readonly Action<object?> commandLogic;
        private readonly Func<object?, bool> commandGuard;
        
        public event EventHandler? CanExecuteChanged;

        public void NotifyCommand()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public SimpleCommand(Action commandLogic, Func<bool> commandGuard)
        {
            this.commandLogic = (_) => commandLogic();
            this.commandGuard = (_) => commandGuard();
        }

        public bool CanExecute(object? parameter)
        {
            return commandGuard(parameter);
        }

        public void Execute(object? parameter)
        {
            commandLogic(parameter);
        }
    }
}
