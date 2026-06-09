using System.Collections.ObjectModel;
using System.Windows.Input;
using Paige.commands;
using Paige.models;
using Paige.services;


namespace Paige.viewmodels
{
    // Definition of the viewmodel for calendarview
    public class CalendarViewModel : ViewModelBase
    {
        // Dataservice field to load entries
        private readonly DataService _dataService = new DataService();


        // Commands
        // Declare command to go back
        public RelayCommand BackCommand { get; }

        // Delcare command to go to view an entry
        public RelayCommand<ShortEntry> EntryButtonCommand { get; }


        // Properties to expose + make them bindable
        // Entries
        private ObservableCollection<ShortEntry> _entries;
        public ObservableCollection<ShortEntry> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }


        // Constructor
        public CalendarViewModel(ICommand updateViewCommand)
		{
            // Load all entries and store them to the _entries field
            Entries = new ObservableCollection<ShortEntry>(_dataService.LoadAll());

            // If the user clicks the back button, send them back to the main menu
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // If the user clicks an entry in the listbox, switch to the menu and pass the entry
            EntryButtonCommand = new RelayCommand<ShortEntry>(entry => (updateViewCommand as UpdateViewCommand)?.NavigateTo(entry));
		}
	}
}
