using System.Windows;
using System.Windows.Input;
using Paige.commands;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for mainmenuview
    public class MainMenuViewModel : ViewModelBase
    {
        // Commands
        // Declare command to go to the log select menu
        public RelayCommand LogCommand { get; }

        // Declare command to go to the calendar menu
        public RelayCommand CalendarCommand { get; }

        // Declare command to go to the journal select menu
        public RelayCommand JournalCommand { get; }

        // Delcare command to exit the program
        public RelayCommand ExitCommand { get; }


        // Constructor
        public MainMenuViewModel(ICommand updateViewCommand)
        {
            // If log is clicked, go to log select menu
            LogCommand = new RelayCommand(() => updateViewCommand.Execute("logSelect"));

            // Define CalendarCommand (not implemented)
            CalendarCommand = new RelayCommand(() => updateViewCommand.Execute("calendar"));

            // Define JournalCommand (not implemented)
            JournalCommand = new RelayCommand(() => updateViewCommand.Execute("journalSelect"));

            // If exit is clicked, close the program
            ExitCommand = new RelayCommand(() => Application.Current.Shutdown());
        }
    }
}
