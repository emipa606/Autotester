using System.Diagnostics;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using Verse;
using Debug = UnityEngine.Debug;

namespace Autotester;

[HarmonyPatch(typeof(Log), nameof(Log.Error))]
public static class Log_Error
{
    private static readonly string[] allowedStrings =
    [
        "Verbose mode detected",
        "Cannot draw radius ring of radius"
    ];

    public static void Prefix(ref string text)
    {
        var errorText = text;
        if (allowedStrings.Any(allowedString => errorText.Contains(allowedString)))
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

        Debug.LogError(StackTraceUtility.ExtractStackTrace());
        Process.GetCurrentProcess().Kill();
    }
}