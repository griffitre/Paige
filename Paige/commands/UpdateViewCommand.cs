using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Paige.viewmodels;
using Paige.models;
using Paige.views;

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
            if (parameter.ToString() == "logSelect")
            {
                _mainWindowViewModel.ActiveMenu = new LogSelectViewModel(this);
            }
            if (parameter.ToString() == "calendar")
            {
                _mainWindowViewModel.ActiveMenu = new CalendarViewModel(this);
            }
            if (parameter.ToString() == "shortLog")
            {
                _mainWindowViewModel.ActiveMenu = new ShortLogViewModel(this);
            }
            if (parameter.ToString() == "fullLog")
            {
                _mainWindowViewModel.ActiveMenu = new FullLogViewModel(this);
            }
            if (parameter.ToString() == "journalSelect")
            {
                _mainWindowViewModel.ActiveMenu = new JournalSelectViewModel(this);
            }
            if (parameter.ToString() == "journal")
            {
                _mainWindowViewModel.ActiveMenu = new JournalViewModel(this);
            }
            if (parameter.ToString() == "journalCalendar")
            {
                _mainWindowViewModel.ActiveMenu = new JournalCalendarViewModel(this);
            }
        }

        // Method to navigate to a given entry. Which viewmodel to select is determined in the method
        public void NavigateTo(ShortEntry entry)
        {
            // Check if the entry is of type FullEntry. If no, set the active viewmodel to fullentrydetailviewmodel, and cast entry to a type of FullEntry
            if (entry is FullEntry)
            {
                _mainWindowViewModel.ActiveMenu = new FullEntryDetailViewModel((FullEntry)entry, this);
            }
            // Otherwise, set the active viewmodel to shortentrydetailviewmodel, and cast entry to a type of ShortEntry
            else
            {
                _mainWindowViewModel.ActiveMenu = new ShortEntryDetailViewModel(entry, this);
            }
        }

        // Method to navigate to a given journal entry
        public void NavigateToJournal(UserJournalEntry entry)
        {
            _mainWindowViewModel.ActiveMenu = new JournalDetailViewModel(entry, this);
        }
    }
}
