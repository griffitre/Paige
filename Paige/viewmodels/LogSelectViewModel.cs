using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using Paige.commands;
using System.Windows.Input;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for logselectview
    public class LogSelectViewModel : ViewModelBase
    {
        // Commands
        // Declare command to go back
        public RelayCommand BackCommand { get; }

        // Declare command to go to the short log menu
        public RelayCommand ShortLogCommand { get; }

        // Declare command to go to the full log menu
        public RelayCommand FullLogCommand { get; }


        // Constructor
        public LogSelectViewModel(ICommand updateViewCommand)
        {
            // If back button is clicked, go to main menu
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // If short log button is clicked, go to short log view
            ShortLogCommand = new RelayCommand(() => updateViewCommand.Execute("shortLog"));

            // If full log button is clicked, go to full log view
            FullLogCommand = new RelayCommand(() => updateViewCommand.Execute("fullLog"));
        }
    }
}
