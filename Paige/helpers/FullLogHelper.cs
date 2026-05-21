using System;
using System.Collections.Generic;
using System.Text;

namespace Paige.helpers
{
    // Definition for FullLogHelper
    public class FullLogHelper
    {
        // Hobbies dictionary to translate
        private static readonly Dictionary<int, string> HobbiesDict = new()
        {
            { 1, "Gaming" },
            { 2, "Listening to Music" },
            { 3, "Playing Instrument" },
            { 4, "Watching Media" },
            { 5, "Art" },
            { 6, "Reading" },
            { 7, "Journaling" },
            { 8, "Cooking/Baking" },
            { 9, "Gardening" },
            { 10, "Educational Activities" },
        };

        // Meals dictionary to translate
        private static readonly Dictionary<int, string> MealsDict = new()
        {
            { 1, "Home Cooked" },
            { 2, "Fast Food" },
            { 3, "Left Overs" },
            { 4, "Frozen Meals" },
            { 5, "Restaurant" },
            { 6, "Snacks" },
            { 7, "Takeout" }
        };

        // Chores dictionary to translate
        private static readonly Dictionary<int, string> ChoresDict = new()
        {
            { 1, "Dishes" },
            { 2, "Laundry" },
            { 3, "Cooking" },
            { 4, "Housework (i.e. Vacuuming, Mopping, etc)" },
            { 5, "Cleaning Room" }
        };

        // SelfCare dictionary to translate
        private static readonly Dictionary<int, string> SelfCareDict = new()
        {
            { 1, "Exercise" },
            { 2, "Shower" },
            { 3, "Yoga/Meditation" },
            { 4, "Skin Care" },
            { 5, "Massage" },
            { 6, "Outdoors" },
            { 7, "Nap" },
            { 8, "Pray" },
            { 9, "Tried Something New" }
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
            { 1, "Smoking" },
            { 2, "Drinking" },
            { 3, "Cannabis" },
            { 4, "Other" },
        };

        // Weather dictionary to translate
        private static readonly Dictionary<int, string> WeatherDict = new()
        {
            { 1, "Sunny" },
            { 2, "Cloudy" },
            { 3, "Rain/Hail" },
            { 4, "Stormy" },
            { 5, "Snow" },
            { 6, "Windy" },
            { 7, "Cold" },
            { 8, "Hot/Humid" }
        };
    }
}
