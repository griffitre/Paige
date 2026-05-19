using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using Paige.models;

namespace Paige.services
{
    // Class that handles saving and loading data
    public class DataService
    {

        // Create a private readonly string to store the filepath
        private readonly string _filePath;

        public DataService()
        {
            // Get the path to the app data folder
            string roamPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Create the full directory path
            string direcPath = Path.Combine(roamPath, "Paige");

            // Create/ensure the folder is already created
            Directory.CreateDirectory(direcPath);

            // Create the full file path
            string _filepath = Path.Combine(roamPath, "entries.json");
        }

        // Method to load logs from a json file
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
    }
}
