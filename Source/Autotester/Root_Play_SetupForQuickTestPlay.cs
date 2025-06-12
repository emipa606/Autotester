using HarmonyLib;
using Verse;

namespace Autotester;

[HarmonyPatch(typeof(Root_Play), nameof(Root_Play.SetupForQuickTestPlay))]
public static class Root_Play_SetupForQuickTestPlay
{
    public static void Postfix()
    {
        Find.GameInitData.mapSize = 100;
    }
}