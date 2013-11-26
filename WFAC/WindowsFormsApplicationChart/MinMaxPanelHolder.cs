using System.ComponentModel.Composition;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplicationChart
{
	[Export]
	public class MinMaxPanelHolder
	{
		[Import] private MainForm mainForm;

		public void Reset()
		{
			mainForm.xMinTextBox.Text = string.Empty;
			mainForm.xMaxTextBox.Text = string.Empty;
			mainForm.yMinTextBox.Text = string.Empty;
			mainForm.yMaxTextBox.Text = string.Empty;
		}

		public void ChangeViewByTextboxes(object sender, ChartArea mainArea)
		{
			var minMaxTextBox = sender as TextBox;
			if (minMaxTextBox == null) return;

			if (minMaxTextBox.Text.Length > 20) minMaxTextBox.Text = string.Empty;

			double xmin, xmax, ymin, ymax;

			if (double.TryParse(mainForm.xMinTextBox.Text, out xmin))
				if (!mainArea.AxisX.IsLogarithmic || (mainArea.AxisX.IsLogarithmic && xmin > 0))
					if (xmin < mainArea.AxisX.Maximum)
						mainArea.AxisX.Minimum = xmin;

			if (double.TryParse(mainForm.xMaxTextBox.Text, out xmax))
				if (!mainArea.AxisX.IsLogarithmic || (mainArea.AxisX.IsLogarithmic && xmax > 0))
					if (xmax > mainArea.AxisX.Minimum)
						mainArea.AxisX.Maximum = xmax;

			if (double.TryParse(mainForm.yMinTextBox.Text, out ymin))
				if (!mainArea.AxisY.IsLogarithmic || (mainArea.AxisY.IsLogarithmic && ymin > 0))
					if (ymin < mainArea.AxisY.Maximum)
						mainArea.AxisY.Minimum = ymin;

			if (double.TryParse(mainForm.yMaxTextBox.Text, out ymax))
				if (!mainArea.AxisY.IsLogarithmic || (mainArea.AxisY.IsLogarithmic && ymax > 0))
					if (ymax > mainArea.AxisY.Minimum)
						mainArea.AxisY.Maximum = ymax;
		}
	}
}