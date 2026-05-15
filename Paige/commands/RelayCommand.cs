using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Paige.commands
{
    public class RelayCommand : ICommand
    {

        // Define fields of class
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            // Set appropriate variables
            _execute = execute;
            _canExecute = canExecute;

        }

        // Returns true if the command is allowed to execute, defaults to true if no conditions are given (i.e. a button thats always available)
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        // Calls the action
        public void Execute(object parameter)
        {
            _execute();
        }

        // Create CanExecuteChanged event for WPF to listen to, sub/unsub appropriately
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
