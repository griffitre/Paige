using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.models
{
    // Class for a short entry
    public class ShortEntry
    {
        // Date field to store the date it was logged. Automatically is set to the computer's current date
        public DateTime Date { get; set; } = DateTime.Now;

        // Overall field to store the user's mood from 1-5
        public int Overall { get; set; }

        // User's current mood
        public int CurrentMood { get; set; }

        // User's optional note
        public string? Note { get; set; }
    }
}