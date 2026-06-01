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
        // Create a JournalEntry to be passed from the journal calendar view
        

        // Declare BackCommand
        public RelayCommand BackCommand { get; }


        // Expose all possible fields as read only
        public string JournalDay { get; }
        public string? JournalText { get; }


        // Constructor
        public JournalDetailViewModel(UserJournalEntry entry, ICommand updateViewCommand)
        {
            // Define BackCommand
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // Set JournalDay
            JournalDay = entry.Date.ToString("MMMM dd, yyyy");

            // Set JournalText
            JournalText = entry.JournalBody;
        }
    }
}
