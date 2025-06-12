using System.Diagnostics;
using System.Linq;
using HarmonyLib;
using Verse;

namespace Autotester;

[HarmonyPatch(typeof(Log), nameof(Log.Warning))]
public static class Log_Warning
{
    public static void Prefix(ref string text)
    {
        if (text.Contains(" causes compatibility errors by overwriting "))
        {
            var modName = LoadedModManager.RunningMods.Last()?.Name;
            if (text.StartsWith("[") && !text.StartsWith($"[{modName}]"))
            {
                return;
            }
        }

        if (text.Contains("Scatterer"))
        {
            return;
        }

        text = $"[WARNING]: {text}";
    }

    public static void Postfix(string text)
    {
        if (text.StartsWith("[WARNING]"))
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}