using System;

namespace WindowsFormsApplicationChart
{
	public class CutMath
	{
		public double CalcDeltaX(Cut cut)
		{
			return cut.X2 - cut.X1;
		}

		public double CalcDeltaY(Cut cut)
		{
			return cut.Y2 - cut.Y1;
		}

		public double CalcArea(Cut cut, Line line)
		{
			return 0;
		}

		public double CalcSlope(Cut cut)
		{
			if (Math.Abs(cut.X1 - cut.X2) < 1e-10)
				return cut.Y2 >= cut.Y1 ? double.PositiveInfinity : double.NegativeInfinity;

			return (cut.Y2 - cut.Y1) / (cut.X2 - cut.X1);
		}
	}
}