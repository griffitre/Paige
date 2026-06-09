using Microsoft.Win32;
using Paige.commands;
using Paige.models;
using Paige.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for fulllogview
    public class FullLogViewModel : ViewModelBase
    {
        // Dataservice field to save to json file
        private readonly DataService _dataService = new DataService();


        // Commands
        // Declare command to go back to main menu
        public RelayCommand BackCommand { get; }

        // Declare command to save entry
        public RelayCommand DoneCommand { get; }

        // Declare commands for current mood buttons
        public RelayCommand Mood5Command { get; }
        public RelayCommand Mood4Command { get; }
        public RelayCommand Mood3Command { get; }
        public RelayCommand Mood2Command { get; }
        public RelayCommand Mood1Command { get; }

        // Declare commands for overall day buttons
        public RelayCommand Overall1Command { get; }
        public RelayCommand Overall2Command { get; }
        public RelayCommand Overall3Command { get; }
        public RelayCommand Overall4Command { get; }
        public RelayCommand Overall5Command { get; }
        public RelayCommand Overall6Command { get; }
        public RelayCommand Overall7Command { get; }
        public RelayCommand Overall8Command { get; }
        public RelayCommand Overall9Command { get; }
        public RelayCommand Overall10Command { get; }

        // Declare hobby toggle commands
        public RelayCommand ToggleHobbies1Command { get; }
        public RelayCommand ToggleHobbies2Command { get; }
        public RelayCommand ToggleHobbies3Command { get; }
        public RelayCommand ToggleHobbies4Command { get; }
        public RelayCommand ToggleHobbies5Command { get; }
        public RelayCommand ToggleHobbies6Command { get; }
        public RelayCommand ToggleHobbies7Command { get; }
        public RelayCommand ToggleHobbies8Command { get; }
        public RelayCommand ToggleHobbies9Command { get; }
        public RelayCommand ToggleHobbies10Command { get; }

        // Declare meal toggle commands
        public RelayCommand ToggleMeals1Command { get; }
        public RelayCommand ToggleMeals2Command { get; }
        public RelayCommand ToggleMeals3Command { get; }
        public RelayCommand ToggleMeals4Command { get; }
        public RelayCommand ToggleMeals5Command { get; }
        public RelayCommand ToggleMeals6Command { get; }
        public RelayCommand ToggleMeals7Command { get; }

        // Declare chore toggle commands
        public RelayCommand ToggleChores1Command { get; }
        public RelayCommand ToggleChores2Command { get; }
        public RelayCommand ToggleChores3Command { get; }
        public RelayCommand ToggleChores4Command { get; }
        public RelayCommand ToggleChores5Command { get; }

        // Declare selfcare toggle commands
        public RelayCommand ToggleSelfCare1Command { get; }
        public RelayCommand ToggleSelfCare2Command { get; }
        public RelayCommand ToggleSelfCare3Command { get; }
        public RelayCommand ToggleSelfCare4Command { get; }
        public RelayCommand ToggleSelfCare5Command { get; }
        public RelayCommand ToggleSelfCare6Command { get; }
        public RelayCommand ToggleSelfCare7Command { get; }
        public RelayCommand ToggleSelfCare8Command { get; }
        public RelayCommand ToggleSelfCare9Command { get; }

        // Declare social toggle commands
        public RelayCommand ToggleSocial1Command { get; }
        public RelayCommand ToggleSocial2Command { get; }
        public RelayCommand ToggleSocial3Command { get; }
        public RelayCommand ToggleSocial4Command { get; }
        public RelayCommand ToggleSocial5Command { get; }

        // Declare recreational use toggle commands
        public RelayCommand ToggleRecreational1Command { get; }
        public RelayCommand ToggleRecreational2Command { get; }
        public RelayCommand ToggleRecreational3Command { get; }
        public RelayCommand ToggleRecreational4Command { get; }

        // Declare weather toggle commands
        public RelayCommand ToggleWeather1Command { get; }
        public RelayCommand ToggleWeather2Command { get; }
        public RelayCommand ToggleWeather3Command { get; }
        public RelayCommand ToggleWeather4Command { get; }
        public RelayCommand ToggleWeather5Command { get; }
        public RelayCommand ToggleWeather6Command { get; }
        public RelayCommand ToggleWeather7Command { get; }
        public RelayCommand ToggleWeather8Command { get; }

        // Declare command to attach an image
        public RelayCommand AttachImageCommand { get; }


        // Properties to expose + make them bindable
        // JournalNote
        private string? _journalNote;
        public string? JournalNote
        {
            get { return _journalNote ?? ""; }
            set
            {
                _journalNote = value;
                OnPropertyChanged();
            }
        }

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

        // OverallRating
        private int _overallRating;
        public int OverallRating
        {
            get { return _overallRating; }
            set
            {
                _overallRating = value;
                OnPropertyChanged();
            }
        }

        // AttachedImagePath
        private string? _attachedImagePath;
        public string? AttachedImagePath
        {
            get { return _attachedImagePath; }
            set
            {
                _attachedImagePath = value;
                OnPropertyChanged();
            }
        }

        // Hobbies
        private List<int> _hobbies = new List<int>();
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
        private List<int> _meals = new List<int>();
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
        private List<int> _chores = new List<int>();
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
        private List<int> _selfCare = new List<int>();
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
        private List<int> _social = new List<int>();
        public List<int> Social
        {
            get { return _social; }
            set
            {
                _social = value;
                OnPropertyChanged();
            }
        }

        // Recreational
        private List<int> _recreational = new List<int>();
        public List<int> Recreational
        {
            get { return _recreational; }
            set
            {
                _recreational = value;
                OnPropertyChanged();
            }
        }

        // Weather
        private List<int> _weather = new List<int>();
        public List<int> Weather
        {
            get { return _weather; }
            set
            {
                _weather = value;
                OnPropertyChanged();
            }
        }


        // Constructor
        public FullLogViewModel(ICommand updateViewCommand)
        {
            // Define Exit Command
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("logSelect"));

            // Define Done Command
            DoneCommand = new RelayCommand(() => Done(), () => CanSave());

            // Define mood commands to save their respective mood scores to the CurrentMood field
            Mood5Command = new RelayCommand(() => CurrentMood = 5);
            Mood4Command = new RelayCommand(() => CurrentMood = 4);
            Mood3Command = new RelayCommand(() => CurrentMood = 3);
            Mood2Command = new RelayCommand(() => CurrentMood = 2);
            Mood1Command = new RelayCommand(() => CurrentMood = 1);

            // Define overall day commands to save their respective day scores to the OverallRating field
            Overall1Command = new RelayCommand(() => OverallRating = 1);
            Overall2Command = new RelayCommand(() => OverallRating = 2);
            Overall3Command = new RelayCommand(() => OverallRating = 3);
            Overall4Command = new RelayCommand(() => OverallRating = 4);
            Overall5Command = new RelayCommand(() => OverallRating = 5);
            Overall6Command = new RelayCommand(() => OverallRating = 6);
            Overall7Command = new RelayCommand(() => OverallRating = 7);
            Overall8Command = new RelayCommand(() => OverallRating = 8);
            Overall9Command = new RelayCommand(() => OverallRating = 9);
            Overall10Command = new RelayCommand(() => OverallRating = 10);

            // Define hobby toggle commands
            ToggleHobbies1Command = new RelayCommand(() => ToggleSelection(Hobbies, 1, nameof(Hobbies)));
            ToggleHobbies2Command = new RelayCommand(() => ToggleSelection(Hobbies, 2, nameof(Hobbies)));
            ToggleHobbies3Command = new RelayCommand(() => ToggleSelection(Hobbies, 3, nameof(Hobbies)));
            ToggleHobbies4Command = new RelayCommand(() => ToggleSelection(Hobbies, 4, nameof(Hobbies)));
            ToggleHobbies5Command = new RelayCommand(() => ToggleSelection(Hobbies, 5, nameof(Hobbies)));
            ToggleHobbies6Command = new RelayCommand(() => ToggleSelection(Hobbies, 6, nameof(Hobbies)));
            ToggleHobbies7Command = new RelayCommand(() => ToggleSelection(Hobbies, 7, nameof(Hobbies)));
            ToggleHobbies8Command = new RelayCommand(() => ToggleSelection(Hobbies, 8, nameof(Hobbies)));
            ToggleHobbies9Command = new RelayCommand(() => ToggleSelection(Hobbies, 9, nameof(Hobbies)));
            ToggleHobbies10Command = new RelayCommand(() => ToggleSelection(Hobbies, 10, nameof(Hobbies)));

            // Define meal toggle commands
            ToggleMeals1Command = new RelayCommand(() => ToggleSelection(Meals, 1, nameof(Meals)));
            ToggleMeals2Command = new RelayCommand(() => ToggleSelection(Meals, 2, nameof(Meals)));
            ToggleMeals3Command = new RelayCommand(() => ToggleSelection(Meals, 3, nameof(Meals)));
            ToggleMeals4Command = new RelayCommand(() => ToggleSelection(Meals, 4, nameof(Meals)));
            ToggleMeals5Command = new RelayCommand(() => ToggleSelection(Meals, 5, nameof(Meals)));
            ToggleMeals6Command = new RelayCommand(() => ToggleSelection(Meals, 6, nameof(Meals)));
            ToggleMeals7Command = new RelayCommand(() => ToggleSelection(Meals, 7, nameof(Meals)));

            // Define chore toggle commands
            ToggleChores1Command = new RelayCommand(() => ToggleSelection(Chores, 1, nameof(Chores)));
            ToggleChores2Command = new RelayCommand(() => ToggleSelection(Chores, 2, nameof(Chores)));
            ToggleChores3Command = new RelayCommand(() => ToggleSelection(Chores, 3, nameof(Chores)));
            ToggleChores4Command = new RelayCommand(() => ToggleSelection(Chores, 4, nameof(Chores)));
            ToggleChores5Command = new RelayCommand(() => ToggleSelection(Chores, 5, nameof(Chores)));

            // Define selfcare toggle commands
            ToggleSelfCare1Command = new RelayCommand(() => ToggleSelection(SelfCare, 1, nameof(SelfCare)));
            ToggleSelfCare2Command = new RelayCommand(() => ToggleSelection(SelfCare, 2, nameof(SelfCare)));
            ToggleSelfCare3Command = new RelayCommand(() => ToggleSelection(SelfCare, 3, nameof(SelfCare)));
            ToggleSelfCare4Command = new RelayCommand(() => ToggleSelection(SelfCare, 4, nameof(SelfCare)));
            ToggleSelfCare5Command = new RelayCommand(() => ToggleSelection(SelfCare, 5, nameof(SelfCare)));
            ToggleSelfCare6Command = new RelayCommand(() => ToggleSelection(SelfCare, 6, nameof(SelfCare)));
            ToggleSelfCare7Command = new RelayCommand(() => ToggleSelection(SelfCare, 7, nameof(SelfCare)));
            ToggleSelfCare8Command = new RelayCommand(() => ToggleSelection(SelfCare, 8, nameof(SelfCare)));
            ToggleSelfCare9Command = new RelayCommand(() => ToggleSelection(SelfCare, 9, nameof(SelfCare)));

            // Define social toggle commands
            ToggleSocial1Command = new RelayCommand(() => ToggleSelection(Social, 1, nameof(Social)));
            ToggleSocial2Command = new RelayCommand(() => ToggleSelection(Social, 2, nameof(Social)));
            ToggleSocial3Command = new RelayCommand(() => ToggleSelection(Social, 3, nameof(Social)));
            ToggleSocial4Command = new RelayCommand(() => ToggleSelection(Social, 4, nameof(Social)));
            ToggleSocial5Command = new RelayCommand(() => ToggleSelection(Social, 5, nameof(Social)));

            // Define recreational use toggle commands
            ToggleRecreational1Command = new RelayCommand(() => ToggleSelection(Recreational, 1, nameof(Recreational)));
            ToggleRecreational2Command = new RelayCommand(() => ToggleSelection(Recreational, 2, nameof(Recreational)));
            ToggleRecreational3Command = new RelayCommand(() => ToggleSelection(Recreational, 3, nameof(Recreational)));
            ToggleRecreational4Command = new RelayCommand(() => ToggleSelection(Recreational, 4, nameof(Recreational)));

            // Define weather toggle commands
            ToggleWeather1Command = new RelayCommand(() => ToggleSelection(Weather, 1, nameof(Weather)));
            ToggleWeather2Command = new RelayCommand(() => ToggleSelection(Weather, 2, nameof(Weather)));
            ToggleWeather3Command = new RelayCommand(() => ToggleSelection(Weather, 3, nameof(Weather)));
            ToggleWeather4Command = new RelayCommand(() => ToggleSelection(Weather, 4, nameof(Weather)));
            ToggleWeather5Command = new RelayCommand(() => ToggleSelection(Weather, 5, nameof(Weather)));
            ToggleWeather6Command = new RelayCommand(() => ToggleSelection(Weather, 6, nameof(Weather)));
            ToggleWeather7Command = new RelayCommand(() => ToggleSelection(Weather, 7, nameof(Weather)));
            ToggleWeather8Command = new RelayCommand(() => ToggleSelection(Weather, 8, nameof(Weather)));

            // Define Attach Image Command
            AttachImageCommand = new RelayCommand(() => AttachImage());
        }


        // Methods
        // Done method to save to the program's json file in app data
        private void Done()
        {
            // Create an instance of FullEntry to pass to data service to save
            FullEntry userEntry = new FullEntry();

            // Assign the values
            userEntry.CurrentMood = CurrentMood;
            userEntry.Overall = OverallRating;
            userEntry.Note = JournalNote;
            userEntry.AttachedImagePath = AttachedImagePath;
            userEntry.Hobbies = Hobbies;
            userEntry.Meals = Meals;
            userEntry.Chores = Chores;
            userEntry.SelfCare = SelfCare;
            userEntry.Social = Social;
            userEntry.RecreationalUse = Recreational;
            userEntry.Weather = Weather;

            // Call data service to save it
            _dataService.Save(userEntry);
        }

        // AttachImage method
        private void AttachImage()
        {
            // Create a new open file dialogue
            OpenFileDialog dialogue = new OpenFileDialog();

            // Add an image filter
            dialogue.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";

            // Set the initial directory to be the MyPictures folder
            dialogue.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            // Open the dialogue
            if (dialogue.ShowDialog() == true)
            {
                // Get the Paige folder location in app data
                string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paige");

                // Create/ensure that the folder is created
                Directory.CreateDirectory(appDataFolder);

                // Get the images folder
                string imageFolder = Path.Combine(appDataFolder, "Images");

                // Also create/ensure that the folder is created
                Directory.CreateDirectory(imageFolder);

                // Get the file name
                string fileName = Path.GetFileName(dialogue.FileName);

                // Create the destination path
                string destPath = Path.Combine(imageFolder, fileName);

                // Copy the image to the destination with overwriting on
                File.Copy(dialogue.FileName, destPath, overwrite: true);

                // Set the AttachedImagePath field
                AttachedImagePath = destPath;
            }
        }

        // Method to check if the user has unentered options to prevent storing 0s in the CurrentMood and OverallRating fields
        private bool CanSave()
        {
            return CurrentMood != 0 && OverallRating != 0;
        }

        // Method to toggle selections on and off from the int lists
        private void ToggleSelection(List<int> list, int id, string propertyName)
        {
            // Create a copy of the list
            List<int> copy = new List<int>(list);

            // Check if the item is already in the list. If it does, remove it
            if (copy.Contains(id))
            {
                copy.Remove(id);
            }
            // Otherwise, add it
            else
            {
                copy.Add(id);
            }

            // Switch statement using propertyName to allow this method to be used for all toggle commands
            // Compares propertyName to the name of each list, and once a matching list is found, sets it to the copy list and breaks out of the switch
            switch (propertyName)
            {
                // Hobbies
                case nameof(Hobbies):
                    Hobbies = copy;
                    break;

                // Meals
                case nameof(Meals):
                    Meals = copy;
                    break;

                // Chores
                case nameof(Chores):
                    Chores = copy;
                    break;
                
                // SelfCare
                case nameof(SelfCare):
                    SelfCare = copy;
                    break;

                // Social
                case nameof(Social):
                    Social = copy;
                    break;

                // RecreationalUse
                case nameof(Recreational):
                    Recreational = copy;
                    break;

                // Weather
                case nameof(Weather):
                    Weather = copy;
                    break;
            }
        }
    }
}
