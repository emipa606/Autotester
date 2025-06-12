using System.Diagnostics;
using HarmonyLib;
using Verse;

namespace Autotester;

[HarmonyPatch(typeof(Log), nameof(Log.Error))]
public static class Log_Error
{
    public static void Prefix(ref string text)
    {
        if (text.Contains("Verbose mode detected"))
        {
            return;
        }

        text = $"[ERROR]: {text}";
    }

    public static void Postfix(string text)
    {
        if (!text.StartsWith("[ERROR]"))
        {
            return;
        }

        Process.GetCurrentProcess().Kill();
    }
}