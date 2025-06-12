using System.Reflection;
using HarmonyLib;
using Verse;

namespace Autotester;

public class Main : Mod
{
    public Main(ModContentPack content) : base(content)
    {
        new Harmony("Mlie.Autotester").PatchAll(Assembly.GetExecutingAssembly());
    }
}