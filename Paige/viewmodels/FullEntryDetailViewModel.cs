using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Paige.commands;
using Paige.models;
using Paige.services;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for fullentrydetail
    public class FullEntryDetailViewModel : ViewModelBase
    {
        // JournalDataService field to load journal entries (used for the "view today's journal" button)
        private readonly JournalDataService _journalDataService = new JournalDataService();

        // DataService field to delete the entry thats being viewed
        private readonly DataService _dataService = new DataService();


        // Commands
        // Declare command to go back
        public RelayCommand BackCommand { get; }

        // Declare command to go back to the main menu
        public RelayCommand ExitCommand { get; }

        // Declare command to view the attached image
        public RelayCommand ViewImageCommand { get; }

        // Declare command to view the journal from the entry's day
        public RelayCommand<UserJournalEntry> ViewJournalCommand { get; }

        // Declare command to delete the entry thats being viewed
        public RelayCommand DeleteCommand { get; }


        // Properties to expose + make them bindable
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
            // Load the data from the passed entry
            LoadData(entry);

            // Define BackCommand
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("calendar"));

            // Define MainCommand
            ExitCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // Define ViewImageCommand
            ViewImageCommand = new RelayCommand(() => OpenImage(AttachedImagePath));

            // Define ViewJournalCommand
            ViewJournalCommand = new RelayCommand<UserJournalEntry>(TodaysEntry => (updateViewCommand as UpdateViewCommand)?.NavigateToJournal(TodaysEntry, () => (updateViewCommand as UpdateViewCommand)?.NavigateTo(entry)), TodaysEntry => CanViewJournal(TodaysEntry));

            // Define DeleteCommand
            DeleteCommand = new RelayCommand(() => DeleteEntry(entry, updateViewCommand));
        }


        // Methods
        // Method to load all data from a given entry
        private void LoadData(FullEntry entry)
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
        }

        // Method to open the attached image in the user's default image viewer (as long as an image was attached, aka path != null)
        private void OpenImage(string path)
        {
            // If a photo was attached
            if (path != null)
            {
                // Attempt to start the process
                Process.Start(new ProcessStartInfo(Path.GetFullPath(path))
                {
                    // Use shell execute so that it opens in the default viewer
                    UseShellExecute = true
                });
            }
        }

        // Method to check if a returned journal is not null
        private bool CanViewJournal(UserJournalEntry? journalEntry)
        {
            return journalEntry is not null;
        }

        // Method to delete the entry thats being viewed
        private void DeleteEntry(ShortEntry entry, ICommand updateViewCommand)
        {
            // Delete the entry
            _dataService.Delete(entry);

            // Send the user back to the calendar
            updateViewCommand.Execute("calendar");
        }
    }
}
