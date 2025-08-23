# GitHub Copilot Instructions for RimTwins Mod Development

## Mod Overview and Purpose

**RimTwins (Continued)** is a mod for RimWorld that enhances the game's pregnancy and childbirth mechanics by allowing pawns to give birth to twins, triplets, or even quadruplets. This update is a continuation of the original mod by spijkermennos, with new features and improvements to provide a more dynamic and customizable gameplay experience.

### Mod Purpose:
- Allow colonists to give birth to multiple children (twins, triplets, quadruplets)
- Increase player customization with mod options and genetic enhancements

## Key Features and Systems

1. **Recursive Calculation for Births**: 
   - Instead of using set values, the mod employs a recursive approach for calculating multiple births.
   
2. **Mod Options**:
   - Players can configure the chances of multiple births through the mod settings menu. Default chances are set as:
     - Twins: 5%
     - Triplets: 1%
     - Quadruplets: 0.5%
   
3. **Genetic Enhancement**:
   - Introduces a gene that increases the probability of a pawn to have multiple births.
   
4. **Non-Invasive Birth Code**:
   - Instead of overriding the game's birth mechanism, the mod simply calls the birth process again when necessary, preserving base game features.
   
5. **Localization Support**:
   - Added translation strings to support multiple languages.

## Coding Patterns and Conventions

- **Static Classes for Definitions**: Use static classes such as `GeneDefOf` for defining gene definitions.
- **Internal Class Use**: Classes such as `RimTwinsMod` and `RimTwinsSettings` are marked internal for encapsulation within the assembly while keeping them manageable.
- **ModSettings Inheritance**: `RimTwinsSettings` inherits from `ModSettings`, following RimWorld's pattern for settings management.

## XML Integration

- RimWorld utilizes XML for defining game data such as genes, hediffs, and more. Ensure that all XML files are well-documented and validate their structure against RimWorld's XML schema.
- Leverage `<Defs>` to extend or add new definitions where needed (e.g., adding new gene definitions).

## Harmony Patching

- **Setup**: Use Harmony for safe and non-destructive method patching. This ensures compatibility with other mods and the base game.
- **Example**: In `Hediff_Pregnant_DoBirthSpawn`, apply Harmony patches to methods related to childbirth to introduce recursive birth calls.
- **Safety**: Always check for null values and potential side effects before making modifications to game methods.

## Suggestions for Copilot

1. **Error Handling**: Automatically suggest adding error handling or null checks in critical sections of code, particularly within recursion or when interfacing with mod settings.

2. **Commenting and Documentation**: Encourage comments and XML documentation tags in code areas that involve complex logic or recursive methods to aid future developers and Copilot recommendations.

3. **Gene Implementation Collaboration**: Highlight areas where collaboration might enhance mod features, such as gene implementation, and suggest code snippets or documentation links for further study.

4. **Localization**: Suggest adding localization capabilities to new strings or gameplay elements introduced in the code to enhance accessibility.


### Contact and Collaboration

For questions, suggestions, or collaborative opportunities related to the integration of genes or other mod features, please contact us via direct message.

---

This file provides guidelines for using GitHub Copilot with the RimTwins mod project. Please ensure that all contributions adhere to these instructions to maintain code quality and mod integrity.
