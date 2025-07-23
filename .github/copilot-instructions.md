# GitHub Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose
This RimWorld mod is designed to enhance the gameplay experience by improving various in-game systems and providing players with additional debugging and testing tools. The mod implements core functionalities that can be utilized by other mods or for testing game mechanics.

## Key Features and Systems
- **Error and Warning Logging:** The mod includes dedicated classes for logging errors (`Log_Error`) and warnings (`Log_Warning`). These classes serve to improve debugging capabilities during development and gameplay.
- **Main Mod Setup:** The `Main` class inherits from RimWorld's `Mod` class, acting as the entry point for mod initialization and setup.
- **Map Post-Tick Enhancements:** `Map_MapPostTick` provides additional functionality and checks that are executed after each map tick, allowing for custom game logic and optimization.
- **Quick Test Play Setup:** `Root_Play_SetupForQuickTestPlay` is designed to streamline the process of setting up a quick test play environment, useful for testing mod changes rapidly.

## Coding Patterns and Conventions
- **Static Classes for Logging:** Utility classes for logging are implemented as static to ensure they can be easily accessed from anywhere in the codebase without requiring instantiation.
- **Inheritance from Base Mod Class:** The main mod class inherits from RimWorld's `Mod` class to connect with the game lifecycle and configuration seamlessly.
- **Post-Tick Operations:** All operations that should happen after the map's tick are contained within static methods, defined in `Map_MapPostTick`.

## XML Integration
- **XML Files:** While the summary provided does not specify XML integration details, generally, XML files are used to define new game objects, textures, and other assets. Ensure that any XML file related to your mod is correctly referenced within `About.xml` in your mod's directory.
- **Patch Operations:** Use XML for patch operations when adding or removing specific game mechanics to ensure compatibility across different mods.

## Harmony Patching
- **Purpose:** Utilize Harmony for method overriding and patching, allowing for the modification of game methods without directly altering the original game code. This is crucial for maintaining mod stability and compatibility.
- **Pattern:** Patches should be created using Harmony annotations such as `[HarmonyPatch]` and are located, typically, in dedicated patching classes. Ensure patches are reversible and don't leave game state inconsistencies.

## Suggestions for Copilot
- **Autocompletion for Static Log Calls:** Given the presence of static logging classes, ensure Copilot suggests `Log_Error` and `Log_Warning` methods when typing logging statements.
- **Mod Lifecycle Patterns:** Encourage Copilot to suggest setup patterns for the `Main` class, particularly focusing on initializations and event subscriptions common in RimWorld modding.
- **Harmony Annotation Assistance:** Guide Copilot to provide syntax and examples for Harmony patches, enhancing productivity when writing complex patches.
- **XML Asset Suggestions:** When working with XML integration, suggest XML tag structures relevant to RimWorld asset definitions.

By adhering to these guidelines, you'll be able to develop and maintain a robust mod for RimWorld, utilizing the best practices for C# programming and modding techniques.
