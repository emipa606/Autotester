using HarmonyLib;
using Verse;

namespace Autotester;

[HarmonyPatch(typeof(Log), "Error", typeof(string))]
public static class Log_Error
{
    public static void Prefix(ref string text)
    {
        text = $"[ERROR]: {text}";
    }

    public static void Postfix()
    {
        Root.Shutdown();
    }
}