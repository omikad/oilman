using System;
using System.Collections.Generic;

namespace WindowsFormsApplicationChart
{
	[Serializable]
	public class StoreInformation
	{
		/// <summary>
		/// Main line: List of 2 numbers: x, y
		/// </summary>
		public List<double[]> Line { get; set; }

		/// <summary>
		/// Cuts: List of 4 numbers: x1, y1, x2, y2
		/// </summary>
		public List<double[]> Cuts { get; set; }

		public string FileName { get; set; }
	}
}