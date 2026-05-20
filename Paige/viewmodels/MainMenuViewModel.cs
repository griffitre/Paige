using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using Paige.commands;
using System.Windows.Input;

namespace Paige.viewmodels
{
    // Class for main menu view model
    public class MainMenuViewModel : ViewModelBase
    {
        // Declare commands
        public RelayCommand LogCommand { get; }
        public RelayCommand CalendarCommand { get; }
        public RelayCommand JournalCommand { get; }
        public RelayCommand ExitCommand { get; }

        // Define constructor
        public MainMenuViewModel(ICommand updateViewCommand)
        {
            // If log is clicked, go to log select menu
            LogCommand = new RelayCommand(() => updateViewCommand.Execute("logSelect"));

            // Define CalendarCommand (not implemented)
            CalendarCommand = new RelayCommand(() => { });

            // Define JournalCommand (not implemented)
            JournalCommand = new RelayCommand(() => { });

            // If exit is clicked, close the program
            ExitCommand = new RelayCommand(() => Application.Current.Shutdown());
        }
    }
}
