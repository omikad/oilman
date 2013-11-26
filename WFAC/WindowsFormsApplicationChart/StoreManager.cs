using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace WindowsFormsApplicationChart
{
	[Export]
	public class StoreManager
    {
		public StoreInformation Load()
		{
			var filename = OpenFileDialog();
			if (string.IsNullOrWhiteSpace(filename)) return null;

			var storeData = (Path.GetExtension(filename) == ".tda") ? LoadTda(filename) : LoadCsv(filename);
			return storeData;
		}

		public void Save(Chart chart)
		{
			var filename = SaveFileDialog();

			if (string.IsNullOrEmpty(filename) || chart.Series.Count <= 0) return;

			var line = chart.Series.OfType<Line>().First();
			var cuts = chart.Series.OfType<Cut>().ToArray();

			var storeData = new StoreInformation
			{
				Line = line.Points.Select(p => new[] {p.XValue, p.YValues[0]}).ToList(),
				Cuts = cuts.Select(c => new[] {c.X1, c.Y1, c.X2, c.Y2}).ToList(),
				FileName = Path.GetFileName(filename)
			};

			using (var fs = File.OpenWrite(filename))
			{
				var serializer = new XmlSerializer(typeof(StoreInformation));
				serializer.Serialize(fs, storeData);
			}

			MessageBox.Show("Файл сохранен.", string.Empty, MessageBoxButtons.OK);
		}

		private static string OpenFileDialog()
        {
			var dialog = new OpenFileDialog { Filter = "(All files *.*)|*.*|(.csv)|*.csv|(TDA files .tda)|*.tda" };
            dialog.ShowDialog();
            return dialog.FileName;
        }

		private static string SaveFileDialog()
        {
			var dialog = new SaveFileDialog { Filter = "(TDA file .tda)|*.tda" };
            dialog.ShowDialog();
            return dialog.FileName;
        }

		private static StoreInformation LoadCsv(string filename)
		{
			var line =
				File.ReadAllLines(filename)
					.Where(l => !string.IsNullOrWhiteSpace(l))
					.Select(l => l.Split(','))
					.Where(a => a.Length == 2)
					.Select(a =>
					{
						double x, y = 0;
						var isOk = double.TryParse(a[0], out x) && double.TryParse(a[1], out y);
						return new {x, y, isOk};
					})
					.Where(t => t.isOk)
					.Select(t => new[] {t.x, t.y})
					.ToList();
			return new StoreInformation
			{
				Cuts = new List<double[]>(),
				Line = line,
				FileName = Path.GetFileName(filename)
			};
		}

		private static StoreInformation LoadTda(string filename)
		{
			using (var fs = File.OpenRead(filename))
			{
				var serializer = new XmlSerializer(typeof(StoreInformation));
				var result = (StoreInformation)serializer.Deserialize(fs);
				return result;
			}
		}
    }
}
