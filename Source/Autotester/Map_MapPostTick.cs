using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Autotester;

[HarmonyPatch(typeof(Map), "MapPostTick")]
public static class Map_MapPostTick
{
    private static bool defsLoaded;
    private static bool optionsShown;
    private static bool closeModOptions;
    private static bool logShown;

    public static void Postfix()
    {
        if (defsLoaded)
        {
            return;
        }

        if (!logShown && GenTicks.TicksGame > 25)
        {
            Log.TryOpenLogWindow();
            logShown = true;
            return;
        }

        if (GenTicks.TicksGame < 50)
        {
            return;
        }

        var modBeingTested = LoadedModManager.RunningMods.Last();
        if (modBeingTested == null)
        {
            defsLoaded = true;
            Log.Message("[Autotester]: Cannot find any mod.");
            return;
        }

        if (!optionsShown)
        {
            modBeingTested = LoadedModManager.RunningMods.Last();
            optionsShown = true;

            var modObject =
                LoadedModManager.ModHandles.FirstOrDefault(mod => mod.Content.PackageId == modBeingTested.PackageId);
            if (modObject == null)
            {
                Log.Message($"[Autotester]: {modBeingTested.Name} modhandle could not be found.");
                return;
            }

            if (string.IsNullOrEmpty(modObject.SettingsCategory()))
            {
                Log.Message($"[Autotester]: {modBeingTested.Name} has no mod-settings.");
                return;
            }

            var settingsWindow = new Dialog_Options(modObject)
            {
                forcePause = false
            };
            Find.WindowStack.Add(settingsWindow);

            closeModOptions = true;
            return;
        }

        if (GenTicks.TicksGame < 75)
        {
            return;
        }

        if (closeModOptions)
        {
            closeModOptions = false;
            Find.WindowStack.TryRemove(typeof(Dialog_Options));
            return;
        }

        if (GenTicks.TicksGame < 100)
        {
            return;
        }

        defsLoaded = true;

        var autoTestMethod =
            AccessTools.Method("SpawnModContent.DebugAutotests:SpawnModDefs", [typeof(ModContentPack)]);
        if (autoTestMethod == null)
        {
            return;
        }


        if (!modBeingTested.AllDefs.Any())
        {
            Log.Message($"[Autotester]: {modBeingTested.Name} does not have anything to spawn.");
            return;
        }

        Log.Message($"[Autotester]: Spawning all items from {modBeingTested.Name}.");
        autoTestMethod.Invoke(null, [modBeingTested]);
        Current.CameraDriver.SetRootPosAndSize(Current.CameraDriver.MapPosition.ToVector3(), 60f);
    }
}