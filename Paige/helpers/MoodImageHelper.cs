using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.helpers
{
    // Definition for MoodImageHelper
    public static class MoodImageHelper
    {
        // Create the dictionary to translate mood scores to the respective image
        private static readonly Dictionary<int, string> MoodImages = new()
        {
            { 1, "/assets/Mood1Placeholder.png" },
            { 2, "/assets/Mood2Placeholder.png" },
            { 3, "/assets/Mood3Placeholder.png" },
            { 4, "/assets/Mood4Placeholder.png" },
            { 5, "/assets/Mood5Placeholder.png" }
        };

        // Method to get the respective image given the score. Default to neutral (mood 3) if not found (prevents crashes)
        public static string GetImage(int score)
        {
            return MoodImages.TryGetValue(score, out string image) ? image : "/assets/Mood3Placeholder";
        }
    }
}
