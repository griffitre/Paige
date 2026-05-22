using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.models
{
    // Inform json serializer of derived types so it can properly serialize and deserialize fullentries
    using System.Text.Json.Serialization;
    [JsonDerivedType(typeof(ShortEntry), typeDiscriminator: "Short")]
    [JsonDerivedType(typeof(FullEntry), typeDiscriminator: "Full")]

    // Class for a short entry
    public class ShortEntry
    {
        // Entry type field to keep track of what kind of entry the log is
        public EntryType EntryType { get; set; } = EntryType.Short;

        // Date field to store the date it was logged. Automatically is set to the computer's current date
        public DateTime Date { get; set; } = DateTime.Now;

        // Overall field to store the user's mood from 1-5
        public int Overall { get; set; }

        // User's current mood
        public int CurrentMood { get; set; }

        // User's optional note
        public string? Note { get; set; }

        // User's attached image path
        public string? AttachedImagePath { get; set; }
    }
}