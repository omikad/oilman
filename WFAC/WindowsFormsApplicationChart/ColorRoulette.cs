using System.Drawing;

namespace WindowsFormsApplicationChart
{
	public class ColorRoulette
	{
		private readonly Color[] colors = new[]
			{
				Color.Red,
				Color.Magenta,
				Color.DodgerBlue,
				Color.Orange,
				Color.MediumPurple
			};

		private static int current;

		public Color TakeColor()
		{
			var color = colors[current];
			current = (current + 1) % colors.Length;
			return color;
		}
	}
}
