using System.Reflection;
using HarmonyLib;
using Verse;

namespace Autotester;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("Mlie.Autotester").PatchAll(Assembly.GetExecutingAssembly());
    }
}