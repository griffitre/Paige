using Paige.commands;
using Paige.models;
using Paige.services;
using System.Windows.Input;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for journaldetailview
    public class JournalDetailViewModel : ViewModelBase
    {
        // JournalDataService field to load delete the entry thats being viewed
        private readonly JournalDataService _journalDataService = new JournalDataService();


        // Commands
        // Declare command to go back
        public RelayCommand BackCommand { get; }

        // Declare command to go back to the main menu
        public RelayCommand ExitCommand { get; }

        // Declare command to delete the entry thats being viewed
        public RelayCommand DeleteCommand { get; }


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
        public JournalDetailViewModel(UserJournalEntry entry, ICommand updateViewCommand, Action returnAction = null)
        {
            // Load the data from the passed entry
            LoadAll(entry);

            // Define BackCommand to run return action, defaulting to main if return action is not specified
            BackCommand = new RelayCommand(() => 
            {
                if (returnAction != null)
                {
                    returnAction();
                }
                else
                {
                    updateViewCommand.Execute("main");
                }
            });

            // Define ExitCommand
            ExitCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // Define DeleteCommand to run the delete entry, then run return action, defaulting to the main menu if the return action is not given
            DeleteCommand = new RelayCommand(() =>
            {
                DeleteEntry(entry, updateViewCommand);
                if (returnAction != null)
                {
                    returnAction();
                }
                else
                {
                    updateViewCommand.Execute("main");
                }
            });
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

        // Method to delete the entry thats being viewed
        private void DeleteEntry(UserJournalEntry entry, ICommand updateViewCommand)
        {
            // Delete the entry
            _journalDataService.Delete(entry);
        }
    }
}
