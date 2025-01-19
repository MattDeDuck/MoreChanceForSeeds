using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace MoreChanceForSeeds
{
    [BepInPlugin(PLUGIN_GUID, "PotionMoreChanceForSeeds", PLUGIN_VERSION)]
    [BepInProcess("Potion Craft.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "mattdeduck.PotionMoreChanceForSeeds";
        public const string PLUGIN_VERSION = "1.0.0.0";

        public static ManualLogSource Log { get; set; }

        public static ConfigEntry<bool> configCauldronSeeds;
        public static ConfigEntry<bool> configMerchantSeeds;
        public static ConfigEntry<float> configSeedChance;

        private void Awake()
        {
            Log = base.Logger;

            configCauldronSeeds = Config.Bind("General",
                                              "CauldronSeeds",
                                              true,
                                              "Enables/Disables the chance for seeds to drop when adding ingredients to the cauldron");

            configMerchantSeeds = Config.Bind("General",
                                              "MerchantSeeds",
                                              true,
                                              "Enables/Disables the chance for seeds to drop when buying ingredients from merchants");

            configSeedChance = Config.Bind("General",
                                              "SeedChance",
                                              0.33f,
                                              "The percentage float the random chance needs to be under to gain seed(s)");

            Harmony.CreateAndPatchAll(typeof(Plugin));
            Harmony.CreateAndPatchAll(typeof(Functions));
            Harmony.CreateAndPatchAll(typeof(Patches));
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}