using System.Reflection;
using HarmonyLib;
using Verse;

namespace RimTwins;

[StaticConstructorOnStartup]
public static class RimTwins
{
    static RimTwins()
    {
        new Harmony("com.spijkermenno.rimTwins").PatchAll(Assembly.GetExecutingAssembly());
    }
}