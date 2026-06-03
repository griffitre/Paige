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
        // Declare commands for the buttons
        public RelayCommand BackCommand { get; }
        public RelayCommand CalendarCommand { get; }
        public RelayCommand JournalCommand { get; }

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
