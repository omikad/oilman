using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplicationChart
{
    class Line : Series
    {
	    private readonly DataPoint[] pointsOrderedByX;

	    public Line()
	    {
	    }

        public Line(IEnumerable<DataPoint> points)
        {
	        foreach (var point in points)
		        Points.Add(new DataPoint(point.XValue, point.YValues[0]));

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

	    public Tuple<DataPoint, DataPoint> GetLeftRight(double x)
	    {
		    var first = pointsOrderedByX[0];
		    if (x < first.XValue)
			    return Tuple.Create(first, first);

		    var last = pointsOrderedByX[pointsOrderedByX.Length - 1];
		    if (x > last.XValue)
				return Tuple.Create(last, last);

			var min = 0;
			var max = pointsOrderedByX.Length - 1;

			while (max - min > 1)
			{
				var middle = (max + min) / 2;
				if (pointsOrderedByX[middle].XValue < x)
					min = middle;
				else
					max = middle;
			}

			return Tuple.Create(pointsOrderedByX[min], pointsOrderedByX[max]);
	    }
    }
}
