using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using Paige.commands;
using System.Windows.Input;

namespace Paige.viewmodels
{
    // Definition for LogSelectViewModel
    public class LogSelectViewModel : ViewModelBase
    {

        // Declare commands for the buttons
        public RelayCommand BackCommand { get; }
        public RelayCommand ShortLogCommand { get; }
        public RelayCommand FullLogCommand { get; }

        public LogSelectViewModel(ICommand updateViewCommand)
        {
            // If back button is clicked, go to main menu
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // If short log button is clicked, go to main menu
            ShortLogCommand = new RelayCommand(() => updateViewCommand.Execute("shortLog"));

            // Define FullLogCommand (not implemented)
            FullLogCommand = new RelayCommand(() => { });
        }

    }
}
