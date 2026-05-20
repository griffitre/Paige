using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.helpers
{
    // Definition for MoodRatingHelper
    public static class MoodRatingHelper
    {
        // Create the dictionary to translate mood scores to the respective rating
        private static readonly Dictionary<int, string> MoodRatings = new()
        {
            { 1, "Awful" },
            { 2, "Sad" },
            { 3, "Okay" },
            { 4, "Good" },
            { 5, "Great" }
        };

        // Method to get the respective rating given the score. Default to neutral (Okay) if not found (prevents crashes)
        public static string GetRating(int score)
        {
            return MoodRatings.TryGetValue(score, out string rating) ? rating : "Okay";
        }
    }
}
