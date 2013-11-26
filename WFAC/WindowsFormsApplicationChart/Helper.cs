using System.Drawing;

namespace WindowsFormsApplicationChart
{
	public static class Helper
	{
		public static Color Luminance(this Color color, double alpha)
		{
			return Color.FromArgb(
				LuminanceColor(color.R, alpha),
				LuminanceColor(color.G, alpha),
				LuminanceColor(color.B, alpha));
		}

		private static int LuminanceColor(int c, double alpha)
		{
			return 255 - (int) ((255 - c) * alpha);
		}
	}
}
