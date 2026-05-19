using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

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

                
    }
}
