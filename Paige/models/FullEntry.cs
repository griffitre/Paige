using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.models
{
    // Full mood entry class that inherits the first three fields from short entry class
    public class FullEntry : ShortEntry
    {
        // Overwrite the inherited EntryType (just set it again, this time to full instead of short)
        public EntryType EntryType { get; set; } = EntryType.Full;

        // Properties
        // Hobbies
        public List<int> Hobbies { get; set; } = new List<int>();

        // Meals
        public List<int> Meals { get; set; } = new List<int>();

        // Chores
        public List<int> Chores { get; set; } = new List<int>();

        // SelfCare
        public List<int> SelfCare { get; set; } = new List<int>();

        // Social
        public List<int> Social { get; set; } = new List<int>();

        // RecreationalUse
        public List<int> RecreationalUse { get; set; } = new List<int>();

        // Weather
        public List<int> Weather { get; set; } = new List<int>();
    }
}
