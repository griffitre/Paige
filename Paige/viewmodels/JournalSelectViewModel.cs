using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using Paige.commands;
using System.Windows.Input;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for journalselectview
    public class JournalSelectViewModel : ViewModelBase
    {
        // Commands
        // Declare command to go back
        public RelayCommand BackCommand { get; }

        // Declare command to go to the journal calendar menu
        public RelayCommand CalendarCommand { get; }

        // Declare command to go to the journal editing menu
        public RelayCommand JournalCommand { get; }


        // Constructor
        public JournalSelectViewModel(ICommand updateViewCommand)
        {
            // If back button is clicked, go to main menu
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // If calendar button is clicked, go to journal calendar view
            CalendarCommand = new RelayCommand(() => updateViewCommand.Execute("journalCalendar"));

            // If the edit button is clicked, go to the journal view
            JournalCommand = new RelayCommand(() => updateViewCommand.Execute("journal"));
        }
    }
}
