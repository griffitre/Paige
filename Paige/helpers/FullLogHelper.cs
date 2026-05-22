using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.helpers
{
    // Definition for FullLogHelper
    public static class FullLogHelper
    {
        // Hobbies dictionary to translate
        private static readonly Dictionary<int, string> HobbiesDict = new()
        {
            { 1, "Gaming" },
            { 2, "Music" },
            { 3, "Instruments" },
            { 4, "TV/Movies" },
            { 5, "Art" },
            { 6, "Reading" },
            { 7, "Journaling" },
            { 8, "Cooking/Baking" },
            { 9, "Gardening" },
            { 10, "Learning" },
        };

        // Meals dictionary to translate
        private static readonly Dictionary<int, string> MealsDict = new()
        {
            { 1, "Homemade" },
            { 2, "Fast Food" },
            { 3, "Leftovers" },
            { 4, "Frozen" },
            { 5, "Restaurant" },
            { 6, "Snacks/Desserts" },
            { 7, "Takeout/Delivery" }
        };

        // Chores dictionary to translate
        private static readonly Dictionary<int, string> ChoresDict = new()
        {
            { 1, "Dishes" },
            { 2, "Laundry" },
            { 3, "Cooking" },
            { 4, "Housework" },
            { 5, "Cleaning/Tidying up" }
        };

        // SelfCare dictionary to translate
        private static readonly Dictionary<int, string> SelfCareDict = new()
        {
            { 1, "Exercise" },
            { 2, "Shower/Bath" },
            { 3, "Yoga/Meditation" },
            { 4, "Skincare" },
            { 5, "Massage/Spa day" },
            { 6, "Outdoors" },
            { 7, "Nap" },
            { 8, "Pray" },
            { 9, "Something new" }
        };

        // Social dictionary to translate
        private static readonly Dictionary<int, string> SocialDict = new()
        {
            { 1, "Friends" },
            { 2, "Family" },
            { 3, "Relationship" },
            { 4, "Work/School" },
            { 5, "Volunteering" },
        };

        // RecreationalUse dictionary to translate
        private static readonly Dictionary<int, string> RecreationalUseDict = new()
        {
            { 1, "Cigarettes/Cigars" },
            { 2, "Alcohol" },
            { 3, "Cannabis" },
            { 4, "Other substances" },
        };

        // Weather dictionary to translate
        private static readonly Dictionary<int, string> WeatherDict = new()
        {
            { 1, "Sunny" },
            { 2, "Cloudy" },
            { 3, "Rainy/Hail" },
            { 4, "Stormy" },
            { 5, "Snowy" },
            { 6, "Windy" },
            { 7, "Cold" },
            { 8, "Hot/Humid" }
        };

        // General method to take a dictionary and output the associated value
        private static string TranslateScore(Dictionary<int, string> dict, int score)
        {
            return dict.TryGetValue(score, out string value) ? value : "Unknown";
        }

        // Methods to get respective string for each dict
        public static string GetHobby(int score) => TranslateScore(HobbiesDict, score);
        public static string GetMeals(int score) => TranslateScore(MealsDict, score);
        public static string GetChores(int score) => TranslateScore(ChoresDict, score);
        public static string GetSelfCare(int score) => TranslateScore(SelfCareDict, score);
        public static string GetSocial(int score) => TranslateScore(SocialDict, score);
        public static string GetRecreational(int score) => TranslateScore(RecreationalUseDict, score);
        public static string GetWeather(int score) => TranslateScore(WeatherDict, score);
    }
}
