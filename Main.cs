using UnityEngine;
using UnityModManagerNet;

namespace ADOAccuracy
{
    public class Main
    {
        public static bool enabled;

        private static StatsMenu statsMenu;

        static void Load(UnityModManager.ModEntry modEntry)
        {
            modEntry.OnToggle = OnToggle;
        }
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value == enabled) return true;
            enabled = value;

            if (enabled)
            {
                statsMenu = new GameObject().AddComponent<StatsMenu>();
                GameObject.DontDestroyOnLoad(statsMenu);
            }
            return true;
        }
    }
}
