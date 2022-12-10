using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CharterApp
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> _execute;

        private readonly Func<object?, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<object?> execute, Func<object?, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            if (!CanExecute(parameter))
                return;

            _execute?.Invoke(parameter);
        }
        public void UpdateCanExecute()
        {
            CanExecuteChanged?.Invoke(this, new());
        }
    }
}
