using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NWindApp.ViewModels
{
    public class CommandDelegate : ICommand
    {
        Action<object> ExecuteDelegate;
        Func<object, bool> CanExecuteDelegate;

        public CommandDelegate(Func<object,bool> canExecuteDelegate, Action<object> executeDelegate)
        {
            this.ExecuteDelegate = executeDelegate;
            this.CanExecuteDelegate = canExecuteDelegate;
        }

        public event EventHandler CanExecuteChanged;

        public void ChangeCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            //Handler?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            var Handler = CanExecuteDelegate;
            bool Result = false;
            if (Handler!=null)
            {
                Result = Handler(parameter);
            }
            return Result;
        }

        public void Execute(object parameter)
        {
            var Handler = ExecuteDelegate;
            Handler?.Invoke(parameter);
        }
    }
}
