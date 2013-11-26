using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplicationChart
{
	[Export]
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
			var result = 0d;

			var i = 0;
			DataPoint first = null;
			DataPoint last = null;
			DataPoint prevLast = null;
			foreach (var point in line.GetPointsLocalizeSegment(cut.X1, cut.X2))
			{
				if (i == 0) first = point;
				else if (i == 1 && first != null)
				{
					// Left part
					var y = GetMiddlePointY(first.XValue, first.YValues[0], point.XValue, point.YValues[0], cut.X1);
					result += 0.5 * (first.YValues[0] + y) * (cut.X1 - first.XValue);
				}
				else if (last != null)
				{
					// Middle & Right parts
					result += 0.5 * (last.YValues[0] + point.YValues[0]) * (point.XValue - last.XValue);
				}

				prevLast = last;
				last = point;
				i++;
			}

			if (last != null && prevLast != null)
			{
				// We should substract excessed right part
				var y = GetMiddlePointY(prevLast.XValue, prevLast.YValues[0], last.XValue, last.YValues[0], cut.X2);
				result -= 0.5 * (last.YValues[0] + y) * (last.XValue - cut.X2);
			}

			result -= Math.Min(cut.Y1, cut.Y2) * (cut.X2 - cut.X1);

			return result;
		}

		public double CalcSlope(Cut cut)
		{
			if (Math.Abs(cut.X1 - cut.X2) < 1e-10)
				return cut.Y2 >= cut.Y1 ? double.PositiveInfinity : double.NegativeInfinity;

			return (cut.Y2 - cut.Y1) / (cut.X2 - cut.X1);
		}

		/// <summary>
		/// прилипание
		/// </summary>
		/// <param name="line">основная линия графика</param>
		/// <param name="chartX">точка позиции курсора мыши в координатах графика</param>
		public DataPoint CalcStick(Line line, double chartX)
		{
			var leftRight = line.GetLeftRight(chartX);

			var lx = leftRight.Item1.XValue;
			var ly = leftRight.Item1.YValues[0];
			var rx = leftRight.Item2.XValue;
			var ry = leftRight.Item2.YValues[0];
			var x = chartX;

			var y = GetMiddlePointY(lx, ly, rx, ry, x);

			return new DataPoint(x, y);
		}

		public PointF LocationInChart(Chart chart, float xMouse, float yMouse)
		{
			try
			{
				var ca = chart.ChartAreas[0];

				var relInControl = new PointF((xMouse / chart.Width) * 100, (yMouse / chart.Height) * 100);

				//Verify we are inside the Chart Area
				if (relInControl.X < ca.Position.X || relInControl.X > ca.Position.Right
					|| relInControl.Y < ca.Position.Y || relInControl.Y > ca.Position.Bottom) return PointF.Empty;

				var x = ca.AxisX.PixelPositionToValue(xMouse);
				var y = ca.AxisY.PixelPositionToValue(yMouse);

				if (ca.AxisX.IsLogarithmic) x = Math.Pow(10, x);
				if (ca.AxisY.IsLogarithmic) y = Math.Pow(10, y);

				return new PointF((float)x, (float)y);
			}
			catch (InvalidOperationException)
			{
				return PointF.Empty;
			}
		}

		private static double GetMiddlePointY(double lx, double ly, double rx, double ry, double x)
		{
			if (Math.Abs(rx - lx) < 0.0000001)
				return ry;

			return ly + (x - lx) / (rx - lx) * (ry - ly);
		}
	}
}