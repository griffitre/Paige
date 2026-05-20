using System;
using System.Collections.Generic;
using System.Text;
using Paige.commands;
using Paige.models;
using Paige.services;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for calendarview
    public class CalendarViewModel : ViewModelBase
    {
        // Dataservice to load entries
        private readonly DataService _dataService = new DataService();


        // Define the Entries variable
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


        // Declare Commands
        public RelayCommand BackCommand { get; set; }
        public RelayCommand<ShortEntry> ViewEntryCommand { get; set; }


        // Constructor
        public CalendarViewModel(ICommand updateViewCommand)
		{
            // Load all entries and store them to the _entries field
            Entries = new ObservableCollection<ShortEntry>(_dataService.LoadAll());

            // If the user clicks the back button, send them back to the main menu
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // If the user clicks an entry in the listbox, switch to the menu and pass the entry
            ViewEntryCommand = new RelayCommand<ShortEntry>(entry => (updateViewCommand as UpdateViewCommand)?.NavigateToEntry(entry));
		}
	}
}
