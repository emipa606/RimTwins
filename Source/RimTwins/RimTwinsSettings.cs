using Verse;

namespace RimTwins;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class RimTwinsSettings : ModSettings
{
    public float OneMoreChance = 0.05f;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref OneMoreChance, "OneMoreChance", 0.05f);
    }
}