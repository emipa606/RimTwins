using Mlie;
using UnityEngine;
using Verse;

namespace RimTwins;

[StaticConstructorOnStartup]
internal class RimTwinsMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static RimTwinsMod instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public RimTwinsMod(ModContentPack content) : base(content)
    {
        instance = this;
        Settings = GetSettings<RimTwinsSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal RimTwinsSettings Settings { get; }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "RimTwins";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        Settings.OneMoreChance = listing_Standard.SliderLabeled(
            "RiTw.OneMoreChance".Translate(Settings.OneMoreChance.ToStringPercent()), Settings.OneMoreChance, 0.001f,
            0.5f, tooltip: "RiTw.OneMoreChanceTT".Translate());
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("RiTw.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}