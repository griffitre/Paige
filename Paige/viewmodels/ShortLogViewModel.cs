using Paige.commands;
using Paige.models;
using Paige.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for the shortlogview
    public class ShortLogViewModel : ViewModelBase
    {
        // DataService to save to json file
        private readonly DataService _dataService = new DataService();


        // Commands
        // Declare command to go back to main menu
        public RelayCommand ExitCommand { get; }

        // Declare command to save entry
        public RelayCommand DoneCommand { get; }

        // Declare commands for current mood buttons
        public RelayCommand Mood5Command { get; }
        public RelayCommand Mood4Command { get; }
        public RelayCommand Mood3Command { get; }
        public RelayCommand Mood2Command { get; }
        public RelayCommand Mood1Command { get; }

        // Declare command for overall day buttons
        public RelayCommand Overall10Command { get; }
        public RelayCommand Overall9Command { get; }
        public RelayCommand Overall8Command { get; }
        public RelayCommand Overall7Command { get; }
        public RelayCommand Overall6Command { get; }
        public RelayCommand Overall5Command { get; }
        public RelayCommand Overall4Command { get; }
        public RelayCommand Overall3Command { get; }
        public RelayCommand Overall2Command { get; }
        public RelayCommand Overall1Command { get; }

        // Declare command to attach an image
        public RelayCommand AttachImageCommand { get; }


        // Properties to expose + make them bindable
        // JournalNote
        private string? _journalNote;
        public string JournalNote
        {
            get { return _journalNote ?? "Start here... (also optional though)"; }
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


        // Constructor
        public ShortLogViewModel(ICommand updateViewCommand)
        {

            // Define Exit Command (placeholder for now, will implement once I set up navigation between menus)
            ExitCommand = new RelayCommand(() => updateViewCommand.Execute("main"));

            // Define Done Command (uses a placeholder method that just displays what is saved. The intended functionally wont be implemented until I add persistence)
            DoneCommand = new RelayCommand(() => Done(), () => CanSave());

            // Define mood commands to save their respective mood scores to the CurrentMood field
            Mood5Command = new RelayCommand(() => CurrentMood = 5);
            Mood4Command = new RelayCommand(() => CurrentMood = 4);
            Mood3Command = new RelayCommand(() => CurrentMood = 3);
            Mood2Command = new RelayCommand(() => CurrentMood = 2);
            Mood1Command = new RelayCommand(() => CurrentMood = 1);

            // Define overall day commands to save their respective day scores to the OverallRating field
            Overall10Command = new RelayCommand(() => OverallRating = 10);
            Overall9Command = new RelayCommand(() => OverallRating = 9);
            Overall8Command = new RelayCommand(() => OverallRating = 8);
            Overall7Command = new RelayCommand(() => OverallRating = 7);
            Overall6Command = new RelayCommand(() => OverallRating = 6);
            Overall5Command = new RelayCommand(() => OverallRating = 5);
            Overall4Command = new RelayCommand(() => OverallRating = 4);
            Overall3Command = new RelayCommand(() => OverallRating = 3);
            Overall2Command = new RelayCommand(() => OverallRating = 2);
            Overall1Command = new RelayCommand(() => OverallRating = 1);

            // Define Attach Image Command
            AttachImageCommand = new RelayCommand(() => AttachImage());
        }


        // Methods
        // Done method to save to the program's json file in app data
        private void Done()
        {
            // Create an instance of ShortEntry to pass to data service to save
            ShortEntry userEntry = new ShortEntry();

            // Assign the values
            userEntry.CurrentMood = CurrentMood;
            userEntry.Overall = OverallRating;
            userEntry.Note = JournalNote;
            userEntry.AttachedImagePath = AttachedImagePath;

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

        // Method to check if the user has unentered options to prevent storing 0s in the int fields
        private bool CanSave()
        {
            return CurrentMood != 0 && OverallRating != 0;
        }
    }
}
