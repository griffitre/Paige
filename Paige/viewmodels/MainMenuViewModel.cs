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
            // Define LogCommand
            LogCommand = new RelayCommand(() => updateViewCommand.Execute("log"));

            // Define CalendarCommand
            CalendarCommand = new RelayCommand(() => { });

            // Define JournalCommand
            JournalCommand = new RelayCommand(() => { });

            // Define ExitCommand
            ExitCommand = new RelayCommand(() => Application.Current.Shutdown());
        }
    }
}
