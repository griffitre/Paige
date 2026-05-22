using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Paige.viewmodels;
using Paige.models;

namespace Paige.commands
{
    // Command to handle navigation
    class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel _mainWindowViewModel;

        public UpdateViewCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        // Default implementation of ICommand interface
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter.ToString() == "main")
            {
                _mainWindowViewModel.ActiveMenu = new MainMenuViewModel(this);
            }
            if (parameter.ToString() == "shortLog")
            {
                _mainWindowViewModel.ActiveMenu = new ShortLogViewModel(this);
            }
            if (parameter.ToString() == "logSelect")
            {
                _mainWindowViewModel.ActiveMenu = new LogSelectViewModel(this);
            }
            if (parameter.ToString() == "calendar")
            {
                _mainWindowViewModel.ActiveMenu = new CalendarViewModel(this);
            }
            if (parameter.ToString() == "fullLog")
            {
                _mainWindowViewModel.ActiveMenu = new FullLogViewModel(this);
            }
        }

        // Method to naviagate to an entry
        public void NavigateToEntry(ShortEntry entry)
        {
            _mainWindowViewModel.ActiveMenu = new ShortEntryDetailViewModel(entry, this);
        }
    }
}
