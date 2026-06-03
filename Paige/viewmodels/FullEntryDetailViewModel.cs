using Paige.commands;
using Paige.models;
using Paige.services;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using System.Windows.Input;

namespace Paige.viewmodels
{
    public class FullEntryDetailViewModel : ViewModelBase
    {
        // JournalDataService to load journal entries (used for the "view today's journal" button)
        private readonly JournalDataService _journalDataService = new JournalDataService();


        // Declare commands
        public RelayCommand BackCommand { get; set; }
        public RelayCommand MainCommand { get; set; }
        public RelayCommand<UserJournalEntry> ViewJournalCommand { get; set; }


        // Properties to store data from a given entry
        // CurrentMood
        private int _currentMood;
        public int CurrentMood
        {
            get { return _currentMood; }
            set
            {
                _currentMood = value;
                OnPropertyChanged();
            }
        }

        // Overall rating stored
        private int _overallRatingStored;
        public int OverallRatingStored
        {
            get { return _overallRatingStored; }
            set
            {
                _overallRatingStored = value;
                OnPropertyChanged();
            }
        }

        // SavedNote
        private string _savedNote;
        public string SavedNote
        {
            get { return _savedNote; }
            set
            {
                _savedNote = value;
                OnPropertyChanged();
            }
        }

        // AttachedImagePath
        private string _attachedImagePath;
        public string AttachedImagePath
        {
            get { return _attachedImagePath; }
            set
            {
                _attachedImagePath = value;
                OnPropertyChanged();
            }
        }

        // Hobbies
        private List<int> _hobbies;
        public List<int> Hobbies
        {
            get { return _hobbies; }
            set
            {
                _hobbies = value;
                OnPropertyChanged();
            }
        }

        // Meals
        private List<int> _meals;
        public List<int> Meals
        {
            get { return _meals; }
            set
            {
                _meals = value;
                OnPropertyChanged();
            }
        }

        // Chores
        private List<int> _chores;
        public List<int> Chores
        {
            get { return _chores; }
            set
            {
                _chores = value;
                OnPropertyChanged();
            }
        }

        // SelfCare
        private List<int> _selfCare;
        public List<int> SelfCare
        {
            get { return _selfCare; }
            set
            {
                _selfCare = value;
                OnPropertyChanged();
            }
        }

        // Social
        private List<int> _social;
        public List<int> Social
        {
            get { return _social; }
            set
            {
                _social = value;
                OnPropertyChanged();
            }
        }

        // RecreationalUse
        private List<int> _recreationalUse;
        public List<int> RecreationalUse
        {
            get { return _recreationalUse; }
            set
            {
                _recreationalUse = value;
                OnPropertyChanged();
            }
        }

        // Weather
        private List<int> _weather;
        public List<int> Weather
        {
            get { return _weather; }
            set
            {
                _weather = value;
                OnPropertyChanged();
            }
        }

        // TodaysEntry
        private UserJournalEntry? _todaysEntry;
        public UserJournalEntry? TodaysEntry
        {
            get { return _todaysEntry; }
            set
            {
                _todaysEntry = value;
                OnPropertyChanged();
            }
        }


        // Constructor
        public FullEntryDetailViewModel(FullEntry entry, ICommand updateViewCommand)
        {
            // Set all fields using the data from the passed entry
            CurrentMood = entry.CurrentMood;
            OverallRatingStored = entry.Overall;
            SavedNote = entry.Note;
            AttachedImagePath = entry.AttachedImagePath;
            Hobbies = entry.Hobbies;
            Meals = entry.Meals;
            Chores = entry.Chores;
            SelfCare = entry.SelfCare;
            Social = entry.Social;
            RecreationalUse = entry.RecreationalUse;
            Weather = entry.Weather;
            TodaysEntry = _journalDataService.GetDatesEntry(entry.Date);

            // Define BackCommand
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("calendar"));

            // Define MainCommand
            MainCommand = new RelayCommand(() => updateViewCommand.Execute("main"));
            
            // Define ViewJournalCommand
            ViewJournalCommand = new RelayCommand<UserJournalEntry>(TodaysEntry => (updateViewCommand as UpdateViewCommand)?.NavigateToJournal(TodaysEntry), TodaysEntry => CanViewJournal(TodaysEntry));
        }


        // Methods
        // Method to check if a returned journal is not null
        private bool CanViewJournal(UserJournalEntry? journalEntry)
        {
            return journalEntry is not null;
        }
    }
}
