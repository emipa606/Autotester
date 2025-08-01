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
        "Cannot draw radius ring of radius",
        "Could not process def-injections",
        "Could not generate a pawn after",
        "Pawn generation error",
        "Error while generating pawn",
        "coverage has duplicate items",
        "wipeCategories has duplicate categories"
    ];

    public static void Prefix(ref string text, out bool __state)
    {
        __state = false;
        var errorText = text;

        text = $"[ERROR]: {text}";

        if (allowedStrings.Any(allowedString => errorText.Contains(allowedString)))
        {
            return;
        }

        __state = true;
    }

    public static void Postfix(bool __state)
    {
        if (!__state)
        {
            return;
        }

        Debug.LogError(StackTraceUtility.ExtractStackTrace());
        Debug.LogError("[[Autotest failed]]");
        Process.GetCurrentProcess().Kill();
    }
}