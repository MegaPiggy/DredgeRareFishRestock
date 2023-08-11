using HarmonyLib;
using System.Collections.Generic;
using Winch.Core;

namespace RareFishRestock
{
    [HarmonyPatch(typeof(HarvestPOI), nameof(HarvestPOI.Awake))]
    [HarmonyPatch(typeof(HarvestPOI), nameof(HarvestPOI.Start))]
    public static class HarvestPOIPatch
    {
        public static bool HasRelic(this List<HarvestableItemData> itemList)
        {
            foreach (var item in itemList)
            {
                if (item is RelicItemData) return true;
            }
            return false;
        }

        public static bool IsRelicPOI(this HarvestPOIDataModel poiData)
        {
            return poiData.items.HasRelic() || poiData.nightItems.HasRelic();
        }

        public static void Prefix(HarvestPOI __instance)
        {
            if (__instance.harvestPOIData != null && !__instance.harvestPOIData.doesRestock)
            {
                string name = __instance.gameObject.name;
                if (!name.Contains("relic") && !name.Contains("quest-") && !name.Contains("research-item") && !__instance.harvestPOIData.IsRelicPOI())
                {
                    __instance.harvestPOIData.doesRestock = true;
                }
            }
        }
    }
}