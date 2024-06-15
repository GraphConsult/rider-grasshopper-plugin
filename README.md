# Grasshopper Template for JetBrains Rider

This is a template for Grasshopper plugin development in JetBrains Rider.
It includes a sample solution set up in Rider, file templates, and code snippets, with project templates soon to come.

## Installation

1. Clone this repository to your local machine.
2. Open the JetBrains Rider IDE.
3. Load the solution file `RiderGrasshopperTemplate.sln`.
4. If necessary, modify the solution build settings to match your Rhino install directory.
5. Modify the project settings to match your plugin's name and namespace.
6. Build the solution.

## Dependencies

- [Grasshopper](https://www.nuget.org/packages/Grasshopper/)
- [RhinoCommon](https://www.nuget.org/packages/RhinoCommon/) (Implicitly referenced by Grasshopper)

If necessary, you can add these dependencies to your project using the NuGet package manager, but they should be
included by default.
This solution uses `RhinoCommon 8.5.*` targeting `.NETFramework 4.8`.

## Usage

I am still working on a project template for Rhino & Grasshopper plugins.
For now, you can use the `New Grasshopper Component` file templates and code snippets to speed up your development
process.

To Create a New Grasshopper Component:

1. Right-click on the project in the Solution Explorer.
2. Select `Add > New Item`.
3. Choose the `Grasshopper Component` template.
4. Enter a name for your component and click `Add`.
5. Note that the component is `Task-Capable` - i.e structured for multithreading by default.
5. Modify the component's code as needed.

## Contributing

If you have any suggestions or improvements, feel free to open an issue or submit a pull request.
Contributions are always welcome! Contact me at `tech@graphconsult.xyz` if you would like to become a collaborator.

## Contact

For questions or support, please contact me at `tech@graphconsult.xyz` or visit https://www.graphconsult.xyz.
