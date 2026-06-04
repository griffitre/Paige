using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.models
{
    // Class for a journal entry
    public class UserJournalEntry
    {
        // Set the FirstEdited DateTime field
        public DateTime FirstEdited { get; set; } = DateTime.Now;

        // Create the LastEdited DateTime field
        public DateTime LastEdited { get; set; } = DateTime.Now;

        // Create a string to store the user's journal entry
        public string? JournalBody { get; set; }
    }
}
