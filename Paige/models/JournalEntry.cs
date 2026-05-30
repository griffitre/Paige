using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.models
{
    // Class for a journal entry
    public class JournalEntry
    {
        // Set the date
        public DateTime Date { get; set; } = DateTime.Now;

        // Create a string to store the user's journal entry
        public string? JournalBody { get; set; }
    }
}
