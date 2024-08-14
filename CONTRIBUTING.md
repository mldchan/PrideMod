# Contributing to Pride Mod

## Ways to contribute

### Ideas for the mod

The easiest way to contribute to this mod is to create a [GitHub issue](https://github.com/Akatsuki2555/PrideMod/issues) regarding an idea of what should be added in the mod. If I have free time, I might add your feature in the mod and release an update for it.

### Code Contributing

You can also fork the repository and contribute your code to your fork and then open a pull request. When doing so, make sure to follow the guidelines mentioned below.

## Code Contributing Guidelines

### Code formatting

When writing code, make sure to follow the C# naming guidelines, and make sure your code is readable. Avoid nesting way too many if statements, instead invert if statements. If you have the time, be sure to add a few comments describing the code a little bit so that other people know what you wrote. Avoid using performance degrading code, e.g. `GameObject.Find` in the `Update` method. If you don't need to get the GameObject every single frame, store it in a variable instead.

### Commit Messages

Make sure your commit messages make sense, are short and describe your work straight to the point. For example, don't use Fixed bug, instead append a short description of what bug you've fixed, like Fixed Pride UI not working for example. When adding features, it's enough to just use the feature name, like Added a new theme is enough.

### Limit the number of commits

Avoid unnecessary commits, and when you develop locally, instead of commiting and pushing your work immediately, commit it only, test it locally and if you find any bugs, fix them and then amend your commit to have one commit instead of 2 commits. Similarly, you can create a branch on your fork, do as many commits as possible, then open a pull request from that branch to the main branch of your fork, and use "Merge and Squash" instead of the default "Merge" operation.