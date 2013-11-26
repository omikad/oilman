using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;

namespace WindowsFormsApplicationChart
{
	[Export]
	public class ExcelWriter
	{
		[Import] private CutMath cutMath;

		public void Export(Chart chart)
		{
			var cuts = chart.Series.OfType<Cut>().ToArray();
			if (cuts.Length == 0) return;

			var file = new FileInfo(Path.Combine(Environment.CurrentDirectory,
				string.Format("{0}.xlsx", DateTime.Now.ToString("yy-MM-dd hh-mm-ss"))));

			using (var p = new ExcelPackage(file))
			{
				p.Workbook.Properties.Author = "omikad";
				p.Workbook.Properties.Title = "TDA v1 Oil Company Project Well Name";

				var ws = p.Workbook.Worksheets.Add("Run");

				ws.Cells[1, 1].Value = "X1";
				ws.Cells[1, 2].Value = "Y1";
				ws.Cells[1, 3].Value = "X2";
				ws.Cells[1, 4].Value = "Y2";
				ws.Cells[1, 5].Value = "DeltaX";
				ws.Cells[1, 6].Value = "DeltaY";
				ws.Cells[1, 7].Value = "Area";
				ws.Cells[1, 8].Value = "Slope";

				var line = chart.Series.OfType<Line>().First();

				var row = 3;
				foreach (var cut in cuts)
				{
					ws.Cells[row, 1].Value = cut.X1;
					ws.Cells[row, 2].Value = cut.Y1;
					ws.Cells[row, 3].Value = cut.X2;
					ws.Cells[row, 4].Value = cut.Y2;
					ws.Cells[row, 5].Value = cutMath.CalcDeltaX(cut);
					ws.Cells[row, 6].Value = cutMath.CalcDeltaY(cut);
					ws.Cells[row, 7].Value = cutMath.CalcArea(cut, line);
					ws.Cells[row, 8].Value = cutMath.CalcSlope(cut);
					row++;
				}

				p.Save();
				Process.Start(file.FullName);
			}
		}
	}
}