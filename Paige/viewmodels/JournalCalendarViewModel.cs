using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Paige.commands;
using Paige.models;
using Paige.services;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for calendarview
    public class JournalCalendarViewModel : ViewModelBase
    {
        // JournalDataService field to load journal entries
        private readonly JournalDataService _journalDataService = new JournalDataService();


        // Commands
        // Declare command to go back
        public RelayCommand BackCommand { get; }

        // Declare command to view a journal entry
        public RelayCommand<UserJournalEntry> JournalEntryButtonCommand { get; }


        // Properties to expose + make them bindable
        // JournalEntries
        private ObservableCollection<UserJournalEntry> _journalEntries;
        public ObservableCollection<UserJournalEntry> JournalEntries
        {
            get {  return _journalEntries; }
            set
            {
                _journalEntries = value;
                OnPropertyChanged();
            }
        }


        // Constructor
        public JournalCalendarViewModel(ICommand updateViewCommand)
        {
            // Load all journal entries, store them to the JournalEntries field
            JournalEntries = new ObservableCollection<UserJournalEntry>(_journalDataService.LoadAll());

            // If the user clicks the back button, send them back to the main menu
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("journalSelect"));

            // If the user clicks an entry, call the navigate to journal method
            JournalEntryButtonCommand = new RelayCommand<UserJournalEntry>(entry => (updateViewCommand as UpdateViewCommand)?.NavigateToJournal(entry, () => (updateViewCommand as UpdateViewCommand)?.Execute("journalCalendar")));
        }
    }
}
