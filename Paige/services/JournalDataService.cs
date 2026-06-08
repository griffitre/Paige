using Paige.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Paige.services
{
    // Class that handles saving and loading journal entries
    public class JournalDataService
    {
        // Properties/Fields
        // Create a readonly string to store the filepath
        private readonly string _filePath;


        // Constructor
        public JournalDataService()
        {
            // Get the path to the app data folder
            string roamPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Create the full directory path
            string direcPath = Path.Combine(roamPath, "Paige");

            // Create/ensure the folder is already created
            Directory.CreateDirectory(direcPath);

            // Create the full file path
            _filePath = Path.Combine(direcPath, "journals.json");
        }


        // Methods
        // Method to load all journal entries from a json file
        public List<UserJournalEntry> LoadAll()
        {
            // Check if the file exists. If it doesnt, just return an empty journal entry list
            if (!File.Exists(_filePath))
            {
                return new List<UserJournalEntry>();
            }

            // Otherwise, read all the serialized data to a string
            string serializedString = File.ReadAllText(_filePath);

            // Then, return the deserialized version of it
            return JsonSerializer.Deserialize<List<UserJournalEntry>>(serializedString);
        }

        // Method to save a journal entry to a json file
        public void Save(UserJournalEntry givenEntry)
        {
            // Load the entries from the user's stored file
            List<UserJournalEntry> loadedEntries = LoadAll();

            // Check if an entry for today already exists
            var existing = loadedEntries.FirstOrDefault(j => j.FirstEdited.Date == givenEntry.FirstEdited.Date);

            // If one does exist, overwrite that entry and replace it with the new one (that is just an extension of the old one)
            if (existing != null)
            {
                loadedEntries[loadedEntries.IndexOf(existing)] = givenEntry;
            }
            // Otherwise, just append it to the end of the list
            else
            {
                loadedEntries.Add(givenEntry);
            }

            // Serialize the list into a string, with WriteIndented = true so that it is easy to read
            string entriesSerialized = JsonSerializer.Serialize(loadedEntries, new JsonSerializerOptions { WriteIndented = true });

            // Write it to the file
            File.WriteAllText(_filePath, entriesSerialized);
        }

        // Method to check if there already exists a journal entry from today
        public UserJournalEntry? GetTodaysEntry()
        {
            // Return the entry of today's date (if found, returns null otherwise by default)
            return LoadAll().FirstOrDefault(j => j.FirstEdited.Date == DateTime.Now.Date);
        }

        // Method to find a journal entry given a date
        public UserJournalEntry? GetDatesEntry(DateTime date)
        {
            return LoadAll().FirstOrDefault(j => j.FirstEdited.Date.Equals(date.Date));
        }
    }
}
