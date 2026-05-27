using Paige.commands;
using Paige.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Paige.viewmodels
{
    public class FullEntryDetailViewModel : ViewModelBase
    {
        // Declare BackCommand (the only command ill use here)
        public RelayCommand BackCommand { get; }


        // Expose all possible fields in an entry as read-only
        public int CurrentMood { get; }
        public int OverallRating { get; }
        public string? Note { get; }
        public string? AttachedImagePath { get; }
        public List<int> Hobbies { get; }
        public List<int> Meals { get; }
        public List<int> Chores { get; }
        public List<int> SelfCare { get; }
        public List<int> Social { get; }
        public List<int> RecreationalUse { get; }
        public List<int> Weather { get; }


        // Constructor
        public FullEntryDetailViewModel(FullEntry entry, ICommand updateViewCommand)
        {
            // Define BackCommand
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("calendar"));

            // Set all fields using the data from the passed entry
            CurrentMood = entry.CurrentMood;
            OverallRating = entry.Overall;
            Note = entry.Note;
            AttachedImagePath = entry.AttachedImagePath;
            Hobbies = entry.Hobbies;
            Meals = entry.Meals;
            Chores = entry.Chores;
            SelfCare = entry.SelfCare;
            Social = entry.Social;
            RecreationalUse = entry.RecreationalUse;
            Weather = entry.Weather;
        }
    }
}
