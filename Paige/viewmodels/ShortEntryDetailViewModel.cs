using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Paige.commands;
using Paige.helpers;
using Paige.models;
using Paige.services;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for shortentrydetail view
    public class ShortEntryDetailViewModel : ViewModelBase
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
        // TranslatedDate
        private string _translatedDate;
        public string TranslatedDate
        {
            get { return _translatedDate; }
            set
            {
                _translatedDate = value;
                OnPropertyChanged();
            }
        }

        // TranslatedImage
        private string _translatedImage;
        public string TranslatedImage
        {
            get { return _translatedImage; }
            set
            {
                _translatedImage = value;
                OnPropertyChanged();
            }
        }

        // TranslatedRating
        private string _translatedRating;
        public string TranslatedRating
        {
            get { return _translatedRating; }
            set
            {
                _translatedRating = value;
                OnPropertyChanged();
            }
        }

        // OverallRatingStored
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
        public ShortEntryDetailViewModel(ShortEntry entry, ICommand updateViewCommand)
        {
            // Load the data from the passed entry
            LoadData(entry);

            // Define BackCommand
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("calendar"));

            // Define ExitCommand
            ExitCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // Define ViewImageCommand
            ViewImageCommand = new RelayCommand(() => OpenImage(AttachedImagePath));

            // Define ViewJournalCommand
            ViewJournalCommand = new RelayCommand<UserJournalEntry>(TodaysEntry => (updateViewCommand as UpdateViewCommand)?.NavigateToJournal(TodaysEntry, () => (updateViewCommand as UpdateViewCommand)?.NavigateTo(entry)), TodaysEntry => CanViewJournal(TodaysEntry));

            // Define DeleteCommand
            DeleteCommand = new RelayCommand(() => DeleteEntry(entry, updateViewCommand));
        }


        // Methods
        // Method to load data from a given entry, as well as setting the viewmodel's properties
        private void LoadData(ShortEntry entry)
        {
            // Set all fields using the data from the passed entry
            TranslatedDate = entry.Date.ToString("dddd, MMMM dd, yyyy");
            TranslatedImage = MoodImageHelper.GetImage(entry.CurrentMood);
            TranslatedRating = MoodRatingHelper.GetRating(entry.CurrentMood);
            OverallRatingStored = entry.Overall;
            SavedNote = entry.Note;
            AttachedImagePath = entry.AttachedImagePath;
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
