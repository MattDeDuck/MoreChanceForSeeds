using PotionCraft.ManagersSystem.Potion.Entities;
using PotionCraft.ManagersSystem.RecipeMap;
using PotionCraft.ManagersSystem;
using PotionCraft.NotificationSystem;
using PotionCraft.ObjectBased.RecipeMap.RecipeMapObject;
using PotionCraft.ObjectBased.UIElements.FloatingText;
using PotionCraft.ScriptableObjects.BuildableInventoryItem;
using PotionCraft.Settings;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MoreChanceForSeeds
{
    class Functions
    {
        private static List<BuildableInventoryItem> allSeeds = BuildableInventoryItem.allBuildableItems[BuildableInventoryItemType.Seed];

        public static void CreateText(string text)
        {
            RecipeMapObject recipeMapObject = Managers.RecipeMap.recipeMapObject;
            RecipeMapManagerPotionBasesSettings asset = Settings<RecipeMapManagerPotionBasesSettings>.Asset;
            Vector2 v = recipeMapObject.transmitterWindow.ViewRect.center;
            CollectedFloatingText.SpawnNewText(asset.floatingTextSelectBase, v, new CollectedFloatingText.FloatingTextContent(text, CollectedFloatingText.FloatingTextContent.Type.Text, 0f), Managers.Game.Cam.transform, false, false);
        }

        public static string GetLastComponent()
        {
            List<AlchemySubstanceComponent> used = Managers.Potion.PotionUsedComponents.components;
            return used[used.Count - 1].Component.name;
        }

        public static int GetRandomInt()
        {
            return Random.Range(1, 4);
        }

        public static bool HasASeed(string seedName)
        {
            return (Seed)allSeeds.Where(s => s.name.Contains(seedName)).FirstOrDefault() == null ? false : true;
        }

        public static float ChanceForSeed()
        {
            return Random.Range(0f, 1f);
        }

        public static Seed ReturnSeed(string name)
        {
            return (Seed)allSeeds.Where(s => s.name.Contains(name)).First();
        }

        public static void GetTheSeed(string name, int random, bool isTrading)
        {
            Seed seed = ReturnSeed(name);
            string seedText = random > 1 ? "seeds" : "seed";
            string txt = "Got " + random + " " + name + " " + seedText + "!";

            if(isTrading)
            {
                Notification.ShowText("More Chance For Seeds", txt, Notification.TextType.LevelUpText);
            }
            else
            {
                CreateText(txt);
            }

            Managers.Player.Inventory.AddItem(seed, random, true, true);
        }
    }
}
