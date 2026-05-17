using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using Paige.commands;
using Paige.models;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for the shortlog view
    public class ShortLogViewModel : ViewModelBase
    {

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


        // Properties to expose + make them bindable
        // JournalNote
        private string? _journalNote;
        public string JournalNote
        {
            get { return _journalNote ?? "Start here..."; }
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


        // Constructor
        public ShortLogViewModel()
        {
            // Define Exit Command (placeholder for now, will implement once I set up navigation between menus)
            ExitCommand = new RelayCommand(() => { });

            // Define Done Command (uses a placeholder method that just displays what is saved. The intended functionally wont be implemented until I add persistence)
            DoneCommand = new RelayCommand(() => DonePlaceHolder());

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
        }



        // Done Command placeholder method
        public void DonePlaceHolder()
        {
            // Print data normally
            Debug.WriteLine("Current Mood: " +  CurrentMood);
            Debug.WriteLine("Overall Rating: " + OverallRating);
            Debug.WriteLine("Journal Note: " + JournalNote);

            // Add it to a ShortEntry class
            ShortEntry printEntry = new ShortEntry();
            printEntry.CurrentMood = CurrentMood;
            printEntry.Overall = OverallRating;
            printEntry.Note = JournalNote;

            // Try to print date and user inputs
            Debug.WriteLine(System.Environment.NewLine);
            Debug.WriteLine("Date: " + printEntry.Date);
            Debug.WriteLine("Current Mood: " + printEntry.CurrentMood);
            Debug.WriteLine("Overall: " + printEntry.Overall);
            Debug.WriteLine("Note: " + printEntry.Note);
        }
    }
}
