using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToolBar.Helpers
{
    public  class RelayCommand: ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canexecute;
        public RelayCommand(Action<object> execute,  Predicate<object> canexecute)
        {
            _execute = execute;
            _canexecute = canexecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canexecute == null ? true : _canexecute(parameter);

        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
