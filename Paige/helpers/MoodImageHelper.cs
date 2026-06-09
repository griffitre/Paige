namespace Paige.helpers
{
    // Definition of MoodImageHelper
    public static class MoodImageHelper
    {
        // MoodImages dictionary to translate
        private static readonly Dictionary<int, string> MoodImages = new()
        {
            { 1, "/assets/mood/Mood1Placeholder.png" },
            { 2, "/assets/mood/Mood2Placeholder.png" },
            { 3, "/assets/mood/Mood3Placeholder.png" },
            { 4, "/assets/mood/Mood4Placeholder.png" },
            { 5, "/assets/mood/Mood5Placeholder.png" }
        };


        // Methods
        // Method to get the respective image given a score. Default to neutral (mood 3) if not found (prevents crashes)
        public static string GetImage(int score)
        {
            return MoodImages.TryGetValue(score, out string image) ? image : "/assets/mood/Mood3Placeholder";
        }
    }
}
