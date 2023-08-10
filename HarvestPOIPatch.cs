using HarmonyLib;

namespace RareFishRestock
{
    [HarmonyPatch(typeof(HarvestPOI), nameof(HarvestPOI.Awake))]
    [HarmonyPatch(typeof(HarvestPOI), nameof(HarvestPOI.Start))]
    public static class HarvestPOIPatch
    {
        public static void Prefix(HarvestPOI __instance)
        {
            if (__instance.harvestPOIData != null)
            {
                __instance.harvestPOIData.doesRestock = true;
            }
        }
    }
}
