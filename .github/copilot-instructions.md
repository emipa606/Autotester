# GitHub Copilot Instructions for RimWorld Modding: Autotester

## Mod Overview and Purpose

The **Autotester** mod is designed to facilitate the testing process for modders before they publish their RimWorld mods. It automates several steps that would usually require manual intervention, thereby speeding up the testing cycle. Although it's mainly beneficial for modders handling a large number of mods, it can benefit any modder looking to streamline their testing procedures. This mod might not be directly useful for regular players or modders who find existing solutions like the Spawn Mod Content mod sufficient for their needs.

## Key Features and Systems

1. **Automatic Mod Testing**: Autotester automatically tests mods by loading them in a controlled test environment. It configures the mod list to prioritize the mod under test.

2. **Quick Load Test Map**: It launches RimWorld with a small (100x100) test map when using the `-quicktest` parameter, ensuring faster load times.

3. **Config Automation**: Opens and closes the configuration settings of the test mod, integrating seamlessly with other installed mods.

4. **Item Spawning and Selection**: Utilizes the Spawn Mod Content mod to spawn all mod-related content and iteratively selects each item to verify correctness.

5. **Error and Warning Logging**: Logs any warnings or errors with identifiable prefixes in the log. The game exits immediately on encountering these issues unless specified otherwise in the mod config.

6. **Translation Template Generation**: Automatically generates an English translation template for all Defs, aiding in the development of multi-language support for the mod.

## Coding Patterns and Conventions

- **File Structure**: The mod contains five C# files, each corresponding to a specific functionality within the mod.

- **Namespace Usage**: Utilize namespaces to organize code logically and maintain readability.

- **Naming Conventions**: Follow C# coding standards for naming conventions. Classes use PascalCase, methods use camelCase, and constants should be in uppercase.

- **Comments and Documentation**: Where applicable, use XML documentation comments to describe classes and methods to facilitate smoother collaboration and code comprehension.

## XML Integration

Although this mod does not directly include any XML files within the version provided, it generates a translation template in a `TranslationTemplate` folder within the source directory. Modders can edit this or create additional XML configuration files as needed.

## Harmony Patching

**Harmony** is used for patching RimWorld's functions to introduce new features or modify existing behaviors without altering the original game files:

- **Postfix and Prefix Attributes**: These are used within classes like `Log_Warning` and `Log_Error` to intercept and handle specific methods in RimWorld's codebase.

- **Patching Techniques**: Employ the `Postfix` technique to execute code after a method runs, ensuring the main functionality is completed beforehand. Use `Prefix` to execute code before the original method, often for validation or setup.

- **Sample Classes**: 
  - `Log_Warning`: Intercepts warning logs and prefixes them for easy identification.
  - `Log_Error`: Extends error logging with custom handling and instant game termination based on conditions.

## Suggestions for Copilot

1. **Repeated Structures**: Utilize Copilot to complete repetitive structures such as loops for item selection and spawning, ensuring consistent syntax and reducing errors.

2. **Error Handling**: Implement common error-handling patterns quickly by suggesting inline comments that describe typical exceptions.

3. **Documentation**: Generate standard XML documentation templates for methods and classes to maintain clarity and assist future contributors.

4. **Method Signatures**: Offer suggestions for method signatures when patching RimWorld functions, ensuring correct alignment with original method parameters.

5. **Code Optimization**: Propose optimizations for nested loops or complex conditions that iterate over game objects or configurations.

By following these guidelines, contributions to the Autotester mod are expected to align with the mod's existing structure while leveraging the full potential of GitHub Copilot for efficient development.

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

