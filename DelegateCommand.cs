using System;
using System.Windows.Input;

namespace NBA
{
    public class DelegateCommand : ICommand
    {
        public Action<object> ExecuteCommand = null;
        public Func<object, bool> CanExecuteCommand = null;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand != null)
            {
                return CanExecuteCommand(parameter);
            }
            else
            {
                return true;
            }
        }
        public void Execute(object parameter)
        {
            if (ExecuteCommand != null)
            {
                ExecuteCommand(parameter);
            }
        }
    }
}
