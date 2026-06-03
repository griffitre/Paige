using Paige.commands;
using Paige.models;
using Paige.services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Paige.viewmodels
{
    public class FullEntryDetailViewModel : ViewModelBase
    {
        // JournalDataService to load journal entries (used for the "view today's journal" button)
        private readonly JournalDataService _journalDataService = new JournalDataService();


        // Declare BackCommand
        public RelayCommand BackCommand { get; }
        public RelayCommand<UserJournalEntry> ViewJournalCommand { get; }


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
        public UserJournalEntry? TodaysEntry { get; }


        // Constructor
        public FullEntryDetailViewModel(FullEntry entry, ICommand updateViewCommand)
        {
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
            TodaysEntry = _journalDataService.GetDatesEntry(entry.Date);

            // Define BackCommand
            BackCommand = new RelayCommand(() => updateViewCommand.Execute("calendar"));

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
