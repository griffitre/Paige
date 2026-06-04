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
        // Declare BackCommand
        public RelayCommand BackCommand { get; set; }


        // Properties to store data from a given entry
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
            // Define BackCommand
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // Set JournalDay
            JournalDay = entry.FirstEdited.ToString("MMMM dd, yyyy");

            // Set JournalText
            JournalText = entry.JournalBody;
        }
    }
}
