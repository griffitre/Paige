using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Input;
using System.IO;
using Paige.commands;
using Paige.models;
using Paige.helpers;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for the shortentrydetail view
    public class ShortEntryDetailViewModel : ViewModelBase
    {
        // Declare commands
        public RelayCommand BackCommand { get; set; }
        public RelayCommand MainCommand { get; set; }
        public RelayCommand ViewImageCommand { get; set; }


        // Properties to store data from a given entry
        // Translated date
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

        // Translated image
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

        // Translated rating
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

        // Attached image path
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


        // Constructor
        public ShortEntryDetailViewModel(ShortEntry entry, ICommand updateViewCommand)
        {
            // Load the data from the passed entry
            LoadData(entry);

            // If the user clicks the back button, send the user back to the calendar menu
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("calendar"));

            // If the user clicks the main button, send the user back to the main menu
            MainCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // If the user clicks the image, open the image in the user's default image viewer
            ViewImageCommand = new RelayCommand(() => OpenImage(AttachedImagePath));
        }


        // Methods
        // Method to load data from a given entry, as well as setting the viewmodel's properties
        private void LoadData(ShortEntry entry)
        {
            // Translate the stored date and set TranslatedDate
            TranslatedDate = entry.Date.ToString("dddd, MMMM dd, yyyy");

            // Translate the saved current mood to the appropriate image and set TranslatedImage
            TranslatedImage = MoodImageHelper.GetImage(entry.CurrentMood);

            // Translate the saved current mood to the appropriate string and set TranslatedRating
            TranslatedRating = MoodRatingHelper.GetRating(entry.CurrentMood);

            // Set OverallRatingStored
            OverallRatingStored = entry.Overall;

            // Set SavedNote
            SavedNote = entry.Note;

            // Set AttachedImagePath
            AttachedImagePath = entry.AttachedImagePath;
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
    }
}
