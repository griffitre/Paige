namespace Paige.models
{
    // Inform json serializer of derived types so it can properly serialize and deserialize fullentries
    using System.Text.Json.Serialization;
    [JsonDerivedType(typeof(ShortEntry), typeDiscriminator: "Short")]
    [JsonDerivedType(typeof(FullEntry), typeDiscriminator: "Full")]

    // Short mood entry class to store ratings about the user's day, as well as an image and a note
    public class ShortEntry
    {
        // Properties/Fields
        // EntryType EntryType to keep track of what kind of entry the entry is
        public EntryType EntryType { get; set; } = EntryType.Short;

        // Date DateTime to store the date it was logged. Automatically is set to the computer's current date
        public DateTime Date { get; set; } = DateTime.Now;

        // Overall int to store the user's overall day rating from 1-10
        public int Overall { get; set; }

        // CurrentMood int to store the user's current mood from 1-5
        public int CurrentMood { get; set; }

        // Optional nullable string to store the user's note for the day
        public string? Note { get; set; }

        // Optional nullable string to store the user's attached image path string
        public string? AttachedImagePath { get; set; }
    }
}
