using Paige.commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Windows.Input;
using System.IO;
using Paige.models;
using System.Drawing;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for journaldetailview
    public class JournalDetailViewModel : ViewModelBase
    {
        // Commands
        // Declare command to go back
        public RelayCommand BackCommand { get; }

        // Declare command to go back to the main menu
        public RelayCommand ExitCommand { get; }


        // Properties to expose + make them bindable
        // JournalDay
        private string _journalDay;
        public string JournalDay
        {
            get { return _journalDay; }
            set
            {
                _journalDay = value;
                OnPropertyChanged();
            }
        }

        // JournalText
        private string? _journalText;
        public string? JournalText
        {
            get { return _journalText; }
            set
            {
                _journalText = value;
                OnPropertyChanged();
            }
        }


        // Constructor
        public JournalDetailViewModel(UserJournalEntry entry, ICommand updateViewCommand)
        {
            // Load the data from the passed entry
            LoadAll(entry);

            // Define BackCommand
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("journalCalendar"));

            // Define ExitCommand
            ExitCommand = new RelayCommand(() => updateViewCommand.Execute("main"));
        }


        // Methods
        // Method to load data
        private void LoadAll(UserJournalEntry entry)
        {
            // Set JournalDay
            JournalDay = entry.FirstEdited.ToString("MMMM dd, yyyy");

            // Set JournalText
            JournalText = entry.JournalBody;
        }
    }
}
