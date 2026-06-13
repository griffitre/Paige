using System.IO;
using System.Text.Json;
using Paige.models;

namespace Paige.services
{
    // Class that handles saving and loading data
    public class DataService
    {
        // Properties/Fields
        // Create a private readonly string to store the filepath
        private readonly string _filePath;

        
        // Constructor
        public DataService()
        {
            // Get the path to the app data folder
            string roamPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Create the full directory path
            string direcPath = Path.Combine(roamPath, "Paige");

            // Create/ensure the folder is already created
            Directory.CreateDirectory(direcPath);

            // Create the full file path
            _filePath = Path.Combine(direcPath, "entries.json");
        }


        // Methods
        // Method to load entries from a json file
        public List<ShortEntry> LoadAll()
        {
            // Check if the file exists. If it doesnt, just return an empty short entry list
            if (!File.Exists(_filePath))
            {
                return new List<ShortEntry>();
            }

            // Otherwise, read all the serialized data to a string
            string serializedString = File.ReadAllText(_filePath);

            // Then, return the deserialized version of it
            return JsonSerializer.Deserialize<List<ShortEntry>>(serializedString);
        }

        // Method to save an entry to a json file
        public void Save(ShortEntry givenEntry)
        {
            // Load the entries from the user's stored file
            List<ShortEntry> loadedEntries = LoadAll();

            // Append the given entry to the list
            loadedEntries.Add(givenEntry);

            // Serialize the list into a string, with WriteIndented = true so that it is easy to read
            string entriesSerialized = JsonSerializer.Serialize(loadedEntries, new JsonSerializerOptions { WriteIndented=true });

            // Write it to the file
            File.WriteAllText(_filePath, entriesSerialized);
        }

        // Method to delete an entry
        public void Delete(ShortEntry entry)
        {
            // Load all entries
            List<ShortEntry> entries = LoadAll();

            // Find the entry to remove
            ShortEntry? toRemove = entries.FirstOrDefault(e => e == entry);

            // Check if entry was found. If so, remove it
            if (toRemove != null)
            {
                entries.Remove(toRemove);
            }

            // Re-serialize and write back to the file
            string jsonString = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented=true });
            File.WriteAllText(_filePath, jsonString);
        }
    }
}
