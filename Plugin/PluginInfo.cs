using System;
using System.Drawing;
using Grasshopper.Kernel;
using GrasshopperPlugin.Properties;

namespace GrasshopperPlugin;

/// <summary>
///   The PluginInfo class provides information about the Grasshopper plugin.
///   It inherits from the GH_AssemblyInfo class which is a part of the Grasshopper.Kernel namespace.
/// </summary>
public class PluginInfo : GH_AssemblyInfo {
    /// <summary>
    ///   Gets the name of the Grasshopper plugin.
    /// </summary>
    public override string Name => nameof(GrasshopperPlugin);

    /// <summary>
    ///   Gets the icon of the Grasshopper plugin.
    /// </summary>
    public override Bitmap Icon => Resources.TaskCapableComponent_24x24;

    /// <summary>
    ///   Gets the description of the Grasshopper plugin.
    /// </summary>
    public override string Description => "Sample Grasshopper task-capable component for Rhinoceros";

    /// <summary>
    ///   Gets the unique identifier of the Grasshopper plugin.
    /// </summary>
    public override Guid Id => new("e0332029-ae49-484c-8ceb-be9b29636df1");

    /// <summary>
    ///   Gets the name of the author of the Grasshopper plugin.
    /// </summary>
    public override string AuthorName => "Graph Technologies";

    /// <summary>
    ///   Gets the contact information of the author of the Grasshopper plugin.
    /// </summary>
    public override string AuthorContact => "tech@graphconsult.xyz";
}