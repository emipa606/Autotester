# Autotester GitHub Copilot Instructions

## Mod Overview and Purpose
**Autotester** is a utility mod designed primarily for RimWorld mod developers to facilitate the testing process before mods are published. It is particularly useful for modders who work with numerous mods, although for most developers, the "Spawn Mod Content" mod suffices for general testing. The key advantage of Autotester is its capability to automate testing processes, which can expedite the development and release cycles.

## Key Features and Systems
- **Automated Test Map Loading:** The mod defines a smaller test map (100x100 tiles) to facilitate faster map loading times when testing mods.
- **Mod Configuration Testing:** Automatically opens and closes any mod configurations related to the mod you are testing.
- **Content Spawning:** Utilizes the "Spawn Mod Content" mod to automatically spawn all content related to the mod being tested.
- **Item Selection Test:** Iteratively selects each item spawned, aiding developers in verifying proper functionality without manual item clicking.
- **Error and Warning Logging:** Stops the game immediately upon encountering errors or warnings, which are prefixed with symbols in the log for easy identification.
- **Translation Template Generation:** Generates an English translation template for all Defs present in the mod, saved in the `TranslationTemplate` folder within the mod's source folder, which can be used for creating translations in other languages.

## Coding Patterns and Conventions
- **Class Design:** Use `public static class` where applicable to define utility functions, such as in `Log_Error` and `Log_Warning`.
- **Inheritance:** The main mod entry class, `Main`, inherits from the `Mod` class which is conventional in RimWorld modding.
- **Consistency:** Follow consistent naming conventions, preferring PascalCase for methods and classes.
- **Error Handling:** Design methods to capture and handle errors gracefully, prioritizing user feedback through logs.

## XML Integration
- **Defs and Data:** Autotester relies on RimWorld's XML data structure for defining game content. Any additions or changes to mods should be properly defined in XML Def files to ensure compatibility with Autotester.
- **Localization:** Resources such as `Def` translations use XML to manage multilingual support. Autotester assists mod developers by generating a translation template for all present Defs.

## Harmony Patching
- Autotester leverages Harmony patches for game behavior modification without directly altering the game's core code.
- For example, `Map_MapPostTick` and `Root_Play_SetupForQuickTestPlay` likely include Harmony patches to intercept and modify game logic during the map post-tick and quick test setup phases respectively.

## Suggestions for Copilot
- **Automate Testing Scripts:** Suggest automations such as additional Harmony patches for common scenarios or complex test sequences.
- **Error Logging Enhancements:** Extend error and warning logging to improve insights, such as including stack traces or additional context information.
- **Map Customization:** Offer ideas for varying map parameters (e.g., terrain, resources) to test different mod interactions.
- **Performance Monitoring:** Implement methods for tracking and reporting mod performance metrics during testing.
- **XML Parsing Helpers:** Develop utility functions to streamline reading and writing complex XML data structures.

By adhering to these instructions and leveraging the Copilot suggestions, developers can enhance their mod testing workflows, streamline error detection and reporting, and facilitate the creation of robust, reliable RimWorld mods.
