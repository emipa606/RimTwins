using HarmonyLib;
using RimWorld;
using Verse;

namespace RimTwins;

[HarmonyPatch(typeof(PregnancyUtility), nameof(PregnancyUtility.ApplyBirthOutcome))]
internal static class PregnancyUtility_ApplyBirthOutcome
{
    public static void Postfix(RitualOutcomePossibility outcome, float quality,
        Precept_Ritual ritual, Pawn geneticMother, Thing birtherThing, Pawn father, Pawn doctor,
        LordJob_Ritual lordJobRitual, RitualRoleAssignments assignments, bool preventLetter)
    {
        //Check for if baby was born in growth vat and don't apply if so.
        if (birtherThing is Building_GrowthVat)
        {
            return;
        }

        if (RimTwins.CurrentlySpawning)
        {
            return;
        }

        var birtherPawn = birtherThing as Pawn;
        //In case mother died during childbirth
        if (birtherPawn?.Dead is true or null)
        {
            return;
        }

        RimTwins.CurrentlySpawning = true;
        var num = 1;

        var extraChance = RimTwins.GetBirthChance(birtherPawn);

        while (Rand.Chance(extraChance))
        {
            //genes is null because it will run GetInheritedGenes in the main function, allowing a random set of genes for the pawn  
            PregnancyUtility.ApplyBirthOutcome(outcome, quality, ritual,
                null, geneticMother,
                birtherThing, father, doctor, lordJobRitual,
                assignments, preventLetter);
            num++;
        }

        RimTwins.CurrentlySpawning = false;

        if (num == 1)
        {
            Messages.Message("RiTw.SingleBaby".Translate(geneticMother.Name.ToStringShort),
                geneticMother,
                MessageTypeDefOf.PositiveEvent);
            return;
        }

        Messages.Message("RiTw.MultipleBabies".Translate(geneticMother.Name.ToStringShort, num),
            geneticMother,
            MessageTypeDefOf.PositiveEvent);
    }
}