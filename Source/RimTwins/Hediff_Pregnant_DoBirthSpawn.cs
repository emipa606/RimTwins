using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace RimTwins;

[HarmonyPatch(typeof(Hediff_Pregnant), nameof(Hediff_Pregnant.DoBirthSpawn))]
public static class Hediff_Pregnant_DoBirthSpawn
{
    private static bool currentlySpawning;

    public static void Postfix(Pawn mother, Pawn father)
    {
        if (!mother.RaceProps.Humanlike || !ModsConfig.BiotechActive)
        {
            return;
        }

        if (currentlySpawning)
        {
            return;
        }

        currentlySpawning = true;
        var num = 1;
        var extraChance = RimTwinsMod.instance.Settings.OneMoreChance;
        if (mother.genes.HasActiveGene(GeneDefOf.MultipleBirths))
        {
            extraChance *= 2f;
        }

        extraChance = Mathf.Clamp(extraChance, 0.001f, 0.75f);

        while (Rand.Chance(extraChance))
        {
            Hediff_Pregnant.DoBirthSpawn(mother, father);
            num++;
        }

        currentlySpawning = false;

        if (num == 1)
        {
            Messages.Message("RiTw.SingleBaby".Translate(mother.Name.ToStringShort), mother,
                MessageTypeDefOf.PositiveEvent);
            return;
        }

        Messages.Message("RiTw.MultipleBabies".Translate(mother.Name.ToStringShort, num), mother,
            MessageTypeDefOf.PositiveEvent);
    }
}