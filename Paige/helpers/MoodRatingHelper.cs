using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.helpers
{
    // Definition of MoodRatingHelper
    public static class MoodRatingHelper
    {
        // MoodRatings dictionary to translate
        private static readonly Dictionary<int, string> MoodRatings = new()
        {
            { 1, "Awful" },
            { 2, "Sad" },
            { 3, "Okay" },
            { 4, "Good" },
            { 5, "Great" }
        };


        // Methods
        // Method to get the respective rating given a score. Default to neutral (Okay) if not found (prevents crashes)
        public static string GetRating(int score)
        {
            return MoodRatings.TryGetValue(score, out string rating) ? rating : "Okay";
        }
    }
}
