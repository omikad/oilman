using System.ComponentModel.Composition;

namespace WindowsFormsApplicationChart
{
	[Export]
	public class CutInfoPanelHolder
	{
		[Import] private MainForm mainForm;
		[Import] private CutMath cutMath;

		public void ClearPanel()
		{
			mainForm.x1TextBox.Text = 0.ToString();
			mainForm.x2TextBox.Text = 0.ToString();
			mainForm.tbDeltaX.Text = 0.ToString();
			mainForm.tbDeltaY.Text = 0.ToString();
			mainForm.tbSlope.Text = 0.ToString();
			mainForm.tbArea.Text = 0.ToString();
		}

		public void RefreshPanel(Cut cut)
		{
			mainForm.x1TextBox.Text = cut.X1.ToString("0.###");
			mainForm.x2TextBox.Text = cut.X2.ToString("0.###");

			mainForm.tbDeltaX.Text = cutMath.CalcDeltaX(cut).ToString("0.##");
			mainForm.tbDeltaY.Text = cutMath.CalcDeltaY(cut).ToString("0.##");
			mainForm.tbSlope.Text = cutMath.CalcSlope(cut).ToString("0.###");

			if (mainForm.MainLine != null)
				mainForm.tbArea.Text = cutMath.CalcArea(cut, mainForm.MainLine).ToString("0.###");
		}
	}
}
