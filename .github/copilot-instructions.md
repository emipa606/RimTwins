# GitHub Copilot Instructions for RimTwins (Continued)

## Mod Overview and Purpose

**RimTwins (Continued)** is a mod for the game RimWorld that enhances its birth mechanics by allowing pawns to give birth to twins, triplets, or quadruplets. This mod is an update to the original mod by spijkermennos and introduces more flexible calculations for multiple births instead of relying solely on set values. Players can adjust the chances of multiple births through mod options, and a new gene system has been added to increase the chances of having multiple births. By integrating these changes, RimTwins provides a richer and more dynamic experience in the aspect of reproduction mechanics.

## Key Features and Systems

- Recursive calculation for determining the number of births in a single pregnancy.
- Mod options for players to customize the chances of multiple births:
  - Twins: 5%
  - Triplets: 1%
  - Quadruplets: 0.5%
- A gene that increases the likelihood of giving birth to multiple children.
- The mod retains the original RimWorld birth code and calls it recursively to manage multiple births.
- Added translation strings for internationalization.

## Coding Patterns and Conventions

- Follows C# practices and conventions with classes being clearly defined as `public`, `internal`, or `static` where appropriate.
- Utilizes a consistent naming scheme for classes and methods that reflect their purpose and functionality.
- Separates functionalities across different files and classes, ensuring modular code structure:
  - `GeneDefOf.cs` for gene definitions.
  - `Hediff_Pregnant_DoBirthSpawn.cs` for handling birth spawning logic.
  - `RimTwins.cs` and `RimTwinsMod.cs` for main mod logic and initialization.
  - `RimTwinsSettings.cs` for storing mod configuration settings.

## XML Integration

- XML files may be used for defining mod configurations and translations. Ensure these files are properly formatted and placed in the `Defs` folder within the mod directory.
- Utilize `<translation>` tags within XML for different languages to support localization.

## Harmony Patching

- Harmony is employed to patch the game's existing methods to insert the mod's functionality seamlessly.
- Ensure patches are non-destructive and maintain compatibility with other mods by using conditional postfix techniques.

## Suggestions for Copilot

When leveraging GitHub Copilot to contribute or extend RimTwins, consider the following:

- **Suggest Methods**: Craft methods that extend existing functionality without duplicating code. Use Copilot's capability to suggest recursive calls and conditionals.
- **Refactor and Optimize**: Use Copilot to propose optimizations and refactors of existing lengthy methods, focusing on readability and performance.
- **Gene System Enhancements**: If expanding the gene functionality, utilize Copilot to suggest implementations that integrate seamlessly with existing gene assignment mechanics in RimWorld.
- **Localization**: Encourage suggestions related to adding or updating translation strings in XML files for better internationalization support.
- **Testing and Debugging**: Leverage Copilot for suggesting unit tests and debugging practices to maintain high code quality and catch potential issues early.

By following these structured guidelines, contributors can ensure consistent development practices and maximize the effectiveness of their collaboration on the RimTwins mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The .github/copilot-instructions.md file is included in the solution under the .github solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution .github copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
