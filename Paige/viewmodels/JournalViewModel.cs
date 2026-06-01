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
            }
        }


        // Constructor
        public JournalViewModel(ICommand updateViewCommand)
        {
            // Define ExitCommand
            ExitCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // Define DoneCommand
            DoneCommand = new RelayCommand(() => Done(), () => CanSave());
        }


        // Methods
        // Method to save entry to json file
        private void Done()
        {
            // Create a journal entry instance
            UserJournalEntry entry = new UserJournalEntry();

            // Set entry's body to be the user's entry that they wrote
            entry.JournalBody = JournalBody;

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
