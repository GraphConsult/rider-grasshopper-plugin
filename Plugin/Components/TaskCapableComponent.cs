using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Grasshopper.Kernel;
using GrasshopperPlugin.Properties;
using Rhino;
using Rhino.Geometry;

namespace GrasshopperPlugin.Components;

public class TaskCapableComponent : GH_TaskCapableComponent<TaskCapableComponent.SolveResults> {
	/// <summary>
	///   Each implementation of GH_Component must provide a public
	///   constructor without any arguments.
	///   Category represents the Tab in which the component will appear,
	///   Subcategory the panel. If you use non-existing tab or panel names,
	///   new tabs/panels will automatically be created.
	/// </summary>
	public TaskCapableComponent()
		: base("Dash Pattern", "Dash", "Convert a curve to a dash pattern.", "Sample", "Task") { }

	public override GH_Exposure Exposure => GH_Exposure.primary | GH_Exposure.obscure;

	/// <summary>
	///   Provides an Icon for every component that will be visible in the User Interface.
	///   Icons need to be 24x24 pixels.
	/// </summary>
	protected override Bitmap Icon => Resources.TaskCapableComponent_24x24;

	/// <summary>
	///   Each component must have a unique Guid to identify it.
	///   It is vital this Guid doesn't change otherwise old .gh / .ghx files
	///   that use the old ID will partially fail during loading.
	/// </summary>
	public override Guid ComponentGuid => new("be2b27e6-0a39-4ba3-82c9-40ab5b3f4fce");

	/// <summary>
	///   Registers all the input parameters for this component.
	/// </summary>
	protected override void RegisterInputParams(GH_InputParamManager input) {
		input.AddCurveParameter("Curve", "C", "Curve to dash", GH_ParamAccess.item);
		input.AddNumberParameter("Pattern", "Pt", "An collection of dash and gap lengths.", GH_ParamAccess.list);
	}

	/// <summary>
	///   Registers all the output parameters for this component.
	/// </summary>
	protected override void RegisterOutputParams(GH_OutputParamManager output) {
		output.AddCurveParameter("Dashes", "D", "Dash segments", GH_ParamAccess.list);
		output.AddCurveParameter("Gaps", "G", "Gap segments", GH_ParamAccess.list);
		output.HideParameter(1);
	}

	/// <summary>
/// Computes the dash pattern for a given curve and pattern.
/// </summary>
/// <param name="crv">The curve to apply the dash pattern to.</param>
/// <param name="pattern">The dash pattern to apply to the curve.</param>
/// <returns>A SolveResults object containing the dash and gap segments, or null if the pattern is empty or the curve is null.</returns>
private SolveResults? Compute(Curve? crv, List<double> pattern) {
    
    var rc = new SolveResults(); // Initialize a new SolveResults object.

    // If the pattern is empty, return null.
    if (pattern.Count == 0) return null;

    double patternLength = 0.0;

    // Calculate the total length of the pattern.
    for (int i = 0; i < pattern.Count; i++) {
        // If a segment of the pattern is negative, set it to 0 and display a warning.
        if (pattern[i] < 0.0) {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Dash patterns cannot have negative length segments");
            pattern[i] = 0.0;
        }
        patternLength += pattern[i];
    }

    // If the total length of the pattern is too short, return the SolveResults object with empty lists.
    if (patternLength <= 1e-12) {
        AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Total pattern length is too short.");
        return rc;
    }
		
    if (crv == null) return rc; // If the curve is null, return the SolveResults object with empty lists.

    
    crv = crv.DuplicateCurve(); // Duplicate the curve to avoid modifying the original.

    // Initialize lists to hold the dash and gap segments.
    List<Curve?> dashes = new();
    List<Curve?> gaps = new();

    int index = -1;
    bool dash = false;

    // Loop until the entire curve has been processed.
    while (true) {
        // Toggle the dash/gap flag.
        dash = !dash; 
        
        index++;
        if (index >= pattern.Count) index = 0;

        // Get the length of the current pattern segment.
        if (Math.Abs(pattern[index]) < 1e-32) {
            if (dash)
                dashes.Add(null);
            else
                gaps.Add(null);
        }
        else {
            // Measure the length of the remaining curve.
            double length = crv.GetLength();
            if (!RhinoMath.IsValidDouble(length)) break;

            // If the remaining curve is shorter than the pattern segment, add it as a dash or gap and break the loop.
            if (length <= pattern[index]) {
                if (dash)
                    dashes.Add(crv);
                else
                    gaps.Add(crv);

                break;
            }

            // Compute the parameter at the end of the pattern segment.
            if (!crv.LengthParameter(pattern[index], out double t)) break;

            // Trim the curve at the end of the pattern segment and add it as a dash or gap.
            var segment = crv.Trim(crv.Domain.Min, t);
            if (segment is { IsValid: true }) {
                if (dash)
                    dashes.Add(segment);
                else
                    gaps.Add(segment);
            }

            // Trim the remaining curve.
            crv = crv.Trim(t, crv.Domain.Max);
            if (crv == null) break;
        }
    }

    // Set the dash and gap lists in the SolveResults object.
    rc.Dashes = dashes;
    rc.Gaps = gaps;

    // Return the SolveResults object.
    return rc;
}

	/// <summary>
	///   This is the method that actually does the work.
	/// </summary>
	/// <param name="data">
	///   The DA object can be used to retrieve data from input parameters and
	///   to store data in output parameters.
	/// </param>
	protected override void SolveInstance(IGH_DataAccess data) {
		if (InPreSolve) {
			// First pass; collect data and construct tasks
			Curve? crv = null;
			List<double> pattern = new();

			Task<SolveResults?>? tsk = null;
			if (data.GetData(0, ref crv) && data.GetDataList(1, pattern))
				tsk = Task.Run(() => Compute(crv, pattern), CancelToken);

			// Add a null task even if data collection fails. This keeps the
			// list size in sync with the iterations
			if (tsk != null) TaskList.Add(tsk!);

			return;
		}

		// This is the compute pass.
		if (!GetSolveResults(data, out var results)) {
			// 1. Collect
			Curve? crv = null;
			List<double> pattern = new();

			if (!data.GetData(0, ref crv)) return;

			if (!data.GetDataList(1, pattern)) return;

			// 2. Compute
			results = Compute(crv, pattern);
		}

		// 3. Set
		if (results?.Dashes == null || results.Gaps == null) return;

		data.SetDataList(0, results.Dashes);
		data.SetDataList(1, results.Gaps);
	}

	/// <summary>
	///   The SolveResults class is a container for the results of the computation performed in the TaskCapableComponent.
	///   It holds two lists of curves, one for dashes and one for gaps, which represent the segments of the original curve
	///   after applying the dash pattern.
	/// </summary>
	public class SolveResults {
		/// <summary>
		///   Gets or sets the list of dash segments. Each item in the list represents a segment of the original curve
		///   that corresponds to a dash in the dash pattern. The list can be null if the computation has not been performed yet.
		/// </summary>
		public List<Curve?>? Dashes { get; set; }

		/// <summary>
		///   Gets or sets the list of gap segments. Each item in the list represents a segment of the original curve
		///   that corresponds to a gap in the dash pattern. The list can be null if the computation has not been performed yet.
		/// </summary>
		public List<Curve?>? Gaps { get; set; }
	}
}