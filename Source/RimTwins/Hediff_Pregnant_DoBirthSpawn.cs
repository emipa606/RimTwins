using HarmonyLib;
using RimWorld;
using Verse;

namespace RimTwins;

[HarmonyPatch(typeof(Hediff_Pregnant), nameof(Hediff_Pregnant.DoBirthSpawn))]
public static class Hediff_Pregnant_DoBirthSpawn
{
    public static void Postfix(Pawn mother, Pawn father)
    {
        if (!mother.RaceProps.Humanlike || !ModsConfig.BiotechActive)
        {
            return;
        }

        if (RimTwins.CurrentlySpawning)
        {
            return;
        }

        RimTwins.CurrentlySpawning = true;
        var num = 1;
        var extraChance = RimTwins.GetBirthChance(mother);

        while (Rand.Chance(extraChance))
        {
            Hediff_Pregnant.DoBirthSpawn(mother, father);
            num++;
        }

        RimTwins.CurrentlySpawning = false;

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