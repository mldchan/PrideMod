# MSCPrideMod

My Summer Car Pride Mod

## Features

### Pride UI

The Pride UI has currently 8 modes to choose from aside from default.
Those modes are:

- Gay/LGBTQ
- Transgender
- Non-Binary
- Pansexual
- Polish
- (NEW) Bisexual
- (NEW) Asexual

And custom. The custom mode allows you to select 7 colors from top to down, which will be applied in that order in-game.

### MSC OwOifier

When enabled, it owoifies text in the game. uwu.
The functions of the owoifier are:

- Smileys - Appends smileys in the text
- Stutter - Add occasional stutter in the text
- Yu

Changes appear instantly, and update when text updates. Everything gets owoified, including texts from mods, MSCLoader and all in-game text.

### Reidentifier

This small feature was part of owoifier but is now separate. Replaces instances of "male", "boy", "man" with different genders, like:

- "woman", "female", "girl"
- "femboy"
- "transfem", "trans girl"
- "transmasc", "trans boy"
- "enby"

### Pride Flags

Adds pride flags in the game. You can spawn preset pride flags or create your own pride flags by choosing individual stripe colors. If any flag is missing, you can create it.
By default, it comes with these flags:

- Lesbian Flag
- Gay Flag
- Bisexual Flag
- Transgender Flag
- Intersex Flag
- Queer Flag

Along with features that allow you to manage spawned flags:

- Delete all flags
- Duplicate all the flags

## Building

To build this mod, you can start by:

1. Clone the repository
2. Optionally switch to the staging branch to apply latest changes to the project, if there are any.
3. Open the project in Visual Studio
4. In the Project panel, locate References, open the tree and remove any references with an exclamation mark next to them.
5. Right click References and click Add Reference. Click Browse in the opened window.
6. Select the following DLLs from `mysummercar_Data\Managed` folder:
    - Assembly-CSharp
    - Assembly-UnityScript
    - PlayMaker
    - MSCLoader
    - UnityEngine
    - UnityEngine.UI
7. On the top of Visual Studio, click Build and Build Solution.
8. Locate the mod in the `bin\Debug` or `bin\Release` folders.

## Contributing

To contribute, refer to [CONTRIBUTING.md](CONTRIBUTING.md)