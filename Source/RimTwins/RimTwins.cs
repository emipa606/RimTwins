using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace RimTwins;

[StaticConstructorOnStartup]
public static class RimTwins
{
    public static bool CurrentlySpawning;

    static RimTwins()
    {
        new Harmony("com.spijkermenno.rimTwins").PatchAll(Assembly.GetExecutingAssembly());
    }

    public static float GetBirthChance(Pawn mother)
    {
        var extraChance = RimTwinsMod.Instance.Settings.OneMoreChance;
        if (mother.genes.HasActiveGene(GeneDefOf.MultipleBirths))
        {
            extraChance *= 2f;
        }

        return Mathf.Clamp(extraChance, 0.001f, 0.75f);
    }
}