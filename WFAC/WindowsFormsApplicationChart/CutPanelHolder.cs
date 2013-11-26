namespace WindowsFormsApplicationChart
{
	public class CutPanelHolder
	{
		private readonly MainForm mainForm;

		public CutPanelHolder(MainForm mainForm)
		{
			this.mainForm = mainForm;
		}

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
			mainForm.tbDeltaX.Text = cut.Lenght.ToString("0.##");
			mainForm.tbDeltaY.Text = cut.Height.ToString("0.##");
			mainForm.tbSlope.Text = cut.Slope.ToString("0.###");
			mainForm.tbArea.Text = cut.Area.ToString("0.###");
		}
	}
}
