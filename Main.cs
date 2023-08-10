using HarmonyLib;
using System.Reflection;

namespace RareFishRestock
{
    public static class Main
    {
        public static void Initialize()
        {
            new Harmony("com.megapiggy.rarefishrestock").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
