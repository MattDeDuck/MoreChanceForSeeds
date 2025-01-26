using HarmonyLib;
using PotionCraft.InventorySystem;
using PotionCraft.ManagersSystem;
using PotionCraft.ManagersSystem.Trade;
using PotionCraft.ObjectBased.Stack;
using PotionCraft.ObjectBased.UIElements.Dialogue;
using PotionCraft.ScriptableObjects;
using System.Collections.Generic;

namespace MoreChanceForSeeds
{
    class Patches
    {
        private static float seedChance = Plugin.configSeedChance.Value;

        [HarmonyPostfix, HarmonyPatch(typeof(Stack), nameof(Stack.AddIngredientPathToMapPath))]
        public static void AddIngredientPathToMapPath_Postfix()
        {
            if(Plugin.configCauldronSeeds.Value)
            {
                float getChance = Functions.ChanceForSeed();
                if (getChance > seedChance)
                {
                    return;
                }

                string last = Functions.GetLastComponent();
                int random = Functions.GetRandomInt();
                if (Functions.HasASeed(last))
                {
                    Functions.GetTheSeed(last, random, false);
                }
            }
        }


        [HarmonyPrefix, HarmonyPatch(typeof(TradeManager), nameof(TradeManager.MakeDeal))]
        public static void MakeDeal_Prefix()
        {
            if(Plugin.configMerchantSeeds.Value)
            {
                TradingPanel tradingPanel2 = Managers.Trade.GetTradingPanel(Inventory.Owner.Trader);
                Inventory tTradingInventory = tradingPanel2.Inventory;
                foreach (KeyValuePair<InventoryItem, int> keyValuePair2 in tTradingInventory.items)
                {
                    float getChance = Functions.ChanceForSeed();
                    if (getChance < seedChance)
                    {
                        string name = keyValuePair2.Key.name;
                        if (Functions.isValidItem(keyValuePair2.Key))
                        {
                            
                        }
                        if(Functions.HasASeed(name))
                        {
                            if (Functions.ReturnSeed(name) != null)
                            {
                                int random = Functions.GetRandomInt();
                                Functions.GetTheSeed(name, random, true);
                            }
                        }
                    }
                }
            }
        }
    }
}
