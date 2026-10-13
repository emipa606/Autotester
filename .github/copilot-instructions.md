# GitHub Copilot Instructions for RimWorld Modding: Autotester

## Mod Overview and Purpose

**Mod Name:** Autotester  
**Author:** Mlie  
**PackageId:** Mlie.Autotester

Autotester is a RimWorld mod designed to streamline the testing process for mod developers before publishing their mods. The tool automates many aspects of testing by utilizing a sequence of predefined actions and interactions within the game, significantly reducing the manual effort required. This mod is particularly useful for developers who manage and test a large collection of mods. While the functionality is similar to the "Spawn Mod Content" mod, Autotester provides extended support for automated batch testing, which can be a valuable resource during development.

## Key Features and Systems

- **Automated Mod Testing:** Load your target mod last in the mod list, and Autotester will perform a suite of tests automatically upon startup.
- **Quicktest Initialization:** By starting RimWorld with the `-quicktest` parameter, the mod will load a smaller test map (100x100) to decrease loading times.
- **Configuration Management:** Opens and closes test-mod configuration to refresh states.
- **Item Spawning:** Uses the Spawn Mod Content to generate all items, facilitating tests across multiple content types.
- **Error Handling:** Instant shutdown on encountering warnings or errors, with a prefix for easy log identification.
- **Translation Template Generation:** Automatically generates a translation template for all Defs in English, aiding multi-language support.

## Coding Patterns and Conventions

- **Naming Conventions:** Follow standard C# conventions with PascalCase used for class names and methods, and camelCase for local variables and parameters.
- **Modular Design:** Each test-related operation should be encapsulated in distinct methods or classes, ensuring single responsibility and making extensions easier.
- **Comments and Documentation:** Code should be well-documented. Use XML comments for public methods to assist with IDE integrations.

## XML Integration

- **Configuration File:** Modify the `Autotester.xml` located in the mod's config folder to manage error exclusions. This XML file defines specific warnings and errors that should be ignored during the automated tests.
- While no XML defs are utilized in this mod beyond configuration, maintaining clear structure and readable nesting in XML files is critical.

## Harmony Patching

The mod uses brrainz.Harmony to apply runtime modifications to existing game code for achieving comprehensive test coverage:

- **Postfix Example:** 
  - Employed predominantly to append additional logic after original method execution, like capturing log outputs or modifying outcomes.
- **Prefix Example:**
  - Used to alter the control flow before running an original method, such as preprocess checks or condition validations.

Ensure that when writing Harmony patches, you:
- Avoid destructive modifications that could impact game integrity outside the scope of testing.
- Properly handle exceptions to prevent mod crashes and save debugging time.
- Utilize unique prefixes to minimize cross-mod interference and conflicts.

## Suggestions for Copilot

Given the mod’s technical requirements, Copilot can significantly assist with:

- **Code Templates:** Automating boilerplate code for Harmony patches and method declarations.
- **Syntax Suggestions:** Providing quick autocomplete for frequently used RimWorld and Harmony functions, reducing potential typo-related errors.
- **Logic Completion:** Generating loop and conditional logic based on natural language comments, which can expedite common patterns (e.g., sequential item processing).
- **Documentation Help:** Auto-generating XML comments for public APIs, ensuring consistent documentation.

By following the aforementioned guidelines and using Copilot efficiently, developers can enhance code quality and speed up the modding process. Happy modding!

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

