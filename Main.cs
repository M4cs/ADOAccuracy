using UnityEngine;
using UnityModManagerNet;
using HarmonyLib;
using System.Reflection;

namespace ADOAccuracy
{
    static class Main
    {
        public static bool enabled;

        public static StatsMenu statsMenu;
        public static string modId = "ADOAccuracy";
        public static Harmony harmony;
        public static UnityModManager.ModEntry modEntry;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            Main.modEntry = modEntry;
            modEntry.OnToggle = OnToggle;
            return true;
        }
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Main.modEntry = modEntry;
            if (value == enabled) return true;
            enabled = value;

            if (enabled)
            {
                harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                Main.statsMenu = new GameObject().AddComponent<StatsMenu>();
                GameObject.DontDestroyOnLoad(statsMenu);

            } else
            {
                harmony.UnpatchAll(harmony.Id);
                GameObject.DestroyImmediate(statsMenu.gameObject);
                statsMenu = null;
            }
            return true;
        }
    }
}
