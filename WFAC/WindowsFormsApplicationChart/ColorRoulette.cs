using System.ComponentModel.Composition;
using System.Drawing;

namespace WindowsFormsApplicationChart
{
	[Export]
	public class ColorRoulette
	{
		private readonly Color[] colors =
		{
			Color.Red,
			Color.Magenta,
			Color.DodgerBlue,
			Color.Orange,
			Color.MediumPurple
		};

		private int current;

		public Color TakeColor()
		{
			var color = colors[current];
			current = (current + 1) % colors.Length;
			return color;
		}
	}
}
