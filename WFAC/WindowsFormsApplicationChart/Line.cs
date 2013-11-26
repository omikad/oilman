using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplicationChart
{
	public class Line : Series
    {
	    private readonly DataPoint[] pointsOrderedByX;

	    public Line()
	    {
	    }

        public Line(StoreInformation storeData)
        {
			foreach (var point in storeData.Line)
		        Points.Add(new DataPoint(point[0], point[1]));

			pointsOrderedByX = Points.OrderBy(p => p.XValue).ToArray();

	        ChartType = SeriesChartType.Line;
            Color = Color.Green;
            BorderWidth = 2;
        }

        public void Draw(Chart chart)
        {
            if (chart.Series.Count > 0) chart.Series.RemoveAt(0);
            chart.Series.Insert(0, this);
        }

		public IEnumerable<DataPoint> GetPointsLocalizeSegment(double x1, double x2)
		{
			int min, max, notused;
			SearchNearest(x1, out min, out notused);
			SearchNearest(x2, out notused, out max);

			for (var i = min; i <= max; i++)
				yield return pointsOrderedByX[i];
		}

	    public Tuple<DataPoint, DataPoint> GetLeftRight(double x)
	    {
		    int min, max;
		    SearchNearest(x, out min, out max);

			return Tuple.Create(pointsOrderedByX[min], pointsOrderedByX[max]);
	    }

		private void SearchNearest(double x, out int min, out int max)
		{
			if (x < pointsOrderedByX[0].XValue)
			{
				min = 0;
				max = 0;
				return;
			}
			
		    var lastIndex = pointsOrderedByX.Length - 1;
			if (x > pointsOrderedByX[lastIndex].XValue)
			{
				min = lastIndex;
				max = lastIndex;
				return;
			}

			min = 0;
			max = lastIndex;

			while (max - min > 1)
			{
				var middle = (max + min) / 2;
				if (pointsOrderedByX[middle].XValue < x)
					min = middle;
				else
					max = middle;
			}
		}
    }
}
