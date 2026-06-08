using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.models
{
    // Full mood entry class that inherits the first three fields from short entry class
    public class FullEntry : ShortEntry
    {
        // Properties/Fields
        // Hobbies list to store which hobbies the user did
        public List<int> Hobbies { get; set; } = new List<int>();

        // Meals list to store which meals the user ate
        public List<int> Meals { get; set; } = new List<int>();

        // Chores list to store which chores the user did
        public List<int> Chores { get; set; } = new List<int>();

        // SelfCare list to store which selfcare activities the user partook in
        public List<int> SelfCare { get; set; } = new List<int>();

        // Social list to store which social activities the user partook in
        public List<int> Social { get; set; } = new List<int>();

        // RecreationalUse list to store which recreational substances the user took
        public List<int> RecreationalUse { get; set; } = new List<int>();

        // Weather list to store the weather for the day
        public List<int> Weather { get; set; } = new List<int>();

        
        // Constructor used to override the inherited EntryType
        public FullEntry()
        {
            EntryType = EntryType.Full;
        }
    }
}
