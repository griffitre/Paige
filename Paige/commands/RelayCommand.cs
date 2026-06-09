using System.Windows.Input;

namespace Paige.commands
{
    // Command used to relay commands/run commands (used by/for buttons that are clicked)
    public class RelayCommand : ICommand
    {
        // Properties/Fields
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;


        // Constructor
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            // Set appropriate variables
            _execute = execute;
            _canExecute = canExecute;
        }


        // Interface implementations
        // Returns true if the command is allowed to execute, defaults to true if no conditions are given
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


    // Definition of a generic relay command that can pass stuff
    public class RelayCommand<T> : ICommand
    {
        // Declare fields of class
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;


        // Constructor
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            // Set appropriate variables
            _execute = execute;
            _canExecute = canExecute;
        }


        // Interface implementations
        // Returns true if the command is allowed to execute, defaults to true if no conditions are given (i.e. a button thats always available)
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        // Calls the action
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        // Create CanExecuteChanged event for WPF to listen to, sub/unsub appropriately
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
