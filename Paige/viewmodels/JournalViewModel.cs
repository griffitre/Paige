using Paige.commands;
using System;
using System.Collections.Generic;
using System.Text;
using Paige.services;
using System.Drawing;
using System.Windows.Input;
using Paige.models;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for journalview
    public class JournalViewModel : ViewModelBase
    {
        // JournalDataService to save journal entries
        private readonly JournalDataService _journalDataService = new JournalDataService();


        // Declare commands
        // ExitCommand
        public RelayCommand ExitCommand { get; }

        // DoneCommand
        public RelayCommand DoneCommand { get; }


        // Expose JournalBody and make it bindable
        private string? _journalBody;
        public string JournalBody
        {
            get { return _journalBody ?? "Start here..."; }
            set
            {
                _journalBody = value;
                OnPropertyChanged();
                System.Windows.Input.CommandManager.InvalidateRequerySuggested();
            }
        }


        // Expose CurrentDate and make it bindable
        private string? _currentDate;
        public string CurrentDate
        {
            get { return _currentDate; }
            set
            {
                _currentDate = value;
                OnPropertyChanged();
            }
        }


        // Create a field to store a loaded FirstEdited field to prevent overwriting
        private DateTime _loadedFirstEdited;
        public DateTime LoadedFirstEdited
        {
            get { return _loadedFirstEdited; }
            set
            {
                _loadedFirstEdited = value;
                OnPropertyChanged();
            }
        }


        // Constructor
        public JournalViewModel(ICommand updateViewCommand)
        {
            // Define ExitCommand
            ExitCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // Define DoneCommand
            DoneCommand = new RelayCommand(() => Done(), () => CanSave());

            // Get the current date in DateTime
            DateTime untranslatedDate = DateTime.Now;

            // Convert date to string and save to currentDate
            CurrentDate = untranslatedDate.ToString("MMMM dd, yyyy");

            // Load today's entry (if it exists)
            var existingEntry = _journalDataService.GetTodaysEntry();

            // If exists, set journalbody to the existing entry, save the loaded FirstEdited field
            if (existingEntry != null)
            {
                _journalBody = existingEntry.JournalBody;
                LoadedFirstEdited = existingEntry.FirstEdited;
            }
            // Otherwise, just set LoadedFirstEdited to the current time, as existingEntry being null means theres no entry from today yet
            else
            {
                LoadedFirstEdited = DateTime.Now;
            }
        }


        // Methods
        // Method to save entry to json file
        private void Done()
        {
            // Create a journal entry instance
            UserJournalEntry entry = new UserJournalEntry();

            // Set entry's body to be the user's entry that they wrote
            entry.JournalBody = JournalBody;

            // Set the FirstEdited field to LoadedFirstEdited
            entry.FirstEdited = LoadedFirstEdited;

            // Set the last edited time
            entry.LastEdited = DateTime.Now;

            // Save the entry
            _journalDataService.Save(entry);
        }

        // Method to check if the user has entered anything for the entry
        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(_journalBody);
        }
    }
}
