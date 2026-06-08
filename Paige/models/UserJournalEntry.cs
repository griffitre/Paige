using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.models
{
    // Journal entry class used to store a user's journal entry, as well as when it was first edited and when it was last edited
    public class UserJournalEntry
    {
        // Properties/Fields
        // FirstEdited DateTime to store when the entry was first edited. Default to now
        public DateTime FirstEdited { get; set; } = DateTime.Now;

        // LastEdited DateTime to store when the entry was last edited. Default to now
        public DateTime LastEdited { get; set; } = DateTime.Now;

        // String to store the user's journal entry
        public string? JournalBody { get; set; }
    }
}
