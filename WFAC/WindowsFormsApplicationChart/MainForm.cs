using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplicationChart
{
	[Export]
    public partial class MainForm : Form
    {
	    [Import] private CutInfoPanelHolder cutInfoPanelHolder;
		[Import] private CutMath cutMath;
		[Import] private ExcelWriter excel;
		[Import] private Func<Cut> createCut;
		[Import] private StoreManager storeManager;
		[Import] private MinMaxPanelHolder minMaxPanelHolder;

		private ChartArea mainArea;
        private double positionX;
        private double positionY;

        public MainForm()
        {
            InitializeComponent();
            Load += mainForm_Load;
        }

	    public Line MainLine { get; private set; }
		
		private void mainForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            mainForm_SizeChanged(this, new EventArgs());
            MainLine = new Line();
            mainArea = chart.ChartAreas[0];
        }

        private void chart_Reset()
        {
            cutCollectionPanel.Controls.Clear();

			chart.Series.Clear();
			cutInfoPanelHolder.ClearPanel();

            MainLine.Points.Clear();

            chart.MouseMove -= chart_MouseMove;
            chart.MouseDown -= chart_MouseDown_Cut;
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            var data = storeManager.Load();
            if (data == null || data.Line.Count <= 0) return;

            chart_Reset();

            MainLine = new Line(data);
            MainLine.Draw(chart);

            mainArea_Set();
            mainArea_Reset();

	        foreach (var cutPoints in data.Cuts)
			{
	            var current = createCut();
				current.Initialize(chart, cutDetailsPanel, cutPoints[0], cutPoints[1], cutPoints[2], cutPoints[3]);
                current.Draw(chart);
                current.AddToPanel(cutCollectionPanel);
            }

            minMaxPanelHolder.Reset();
            zoom_Set();

            chart.MouseMove += chart_MouseMove;
            chart.MouseDown += chart_MouseDown_Cut;
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            storeManager.Save(chart);
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            cutCollectionPanel.Height = cutsPanel.Height - cutDetailsPanel.Height - 10;
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
	        var mousePoint = new Point(e.X, e.Y);

	        mainArea.CursorX.SetCursorPixelPosition(mousePoint, true);
            mainArea.CursorY.SetCursorPixelPosition(mousePoint, true);

			var p = cutMath.LocationInChart(chart, e.X, e.Y);

			positionX = p.X;
            positionY = p.Y;

			mousePositionLabel.Text = string.Format("X = {0}; Y = {1}", p.X, p.Y);
        }

        #region MainArea
        private void mainArea_Set()
        {
            var logX = mainArea.AxisX.IsLogarithmic;
            var logY = mainArea.AxisY.IsLogarithmic;

            chart.ChartAreas.Clear();
            mainArea = new ChartArea
            {
	            AxisX = {IsLogarithmic = logX}, 
				AxisY = {IsLogarithmic = logY}
            };
	        chart.ChartAreas.Add(mainArea);
        }

        private void mainArea_Reset()
        {
            mainArea.AxisX.IsLogarithmic = false;
            mainArea.AxisY.IsLogarithmic = false;

            logCheckBox_HandlerToggle(xLogCheckBox);
            logCheckBox_HandlerToggle(yLogCheckBox);
        }
        #endregion

        #region Zoom
        private void zoom_Set()
        {
            mainArea.CursorX.IsUserEnabled = true;
            mainArea.CursorY.IsUserEnabled = true;
            mainArea.CursorX.IsUserSelectionEnabled = true;
            mainArea.CursorY.IsUserSelectionEnabled = true;
            mainArea.AxisX.ScaleView.Zoomable = true;
            mainArea.AxisY.ScaleView.Zoomable = true;
        }
        #endregion

        #region Logarithmic
        private void logCheckBox_CheckedChanged(object sender, EventArgs e)
        {
			var logCheckBox = sender as CheckBox;
			if (logCheckBox == null) return;

            if (logCheckBox.Checked)
            {
                if (!PointsValid())
                {
                    cut_InfoMessage();
                    logCheckBox_HandlerToggle(xLogCheckBox);
                    logCheckBox_HandlerToggle(yLogCheckBox);
                    return;
                }

				minMaxPanelHolder.Reset();
                mainArea_Set();
                zoom_Set();
            }

            if (logCheckBox == xLogCheckBox)
            {
                if (MainLine.Points[0].XValue <= 0)
                {
                    mainLine_InfoMessage();
                    logCheckBox_HandlerToggle(xLogCheckBox);
                    return;
                }

                mainArea.AxisX.IsLogarithmic = xLogCheckBox.Checked;
            }

			else if (logCheckBox == yLogCheckBox)
            {
                var minY = MainLine.Points[0].YValues[0];
                foreach (var point in MainLine.Points)
                {
                    if (point.YValues[0] < minY) minY = point.YValues[0];
                }

                if (minY <= 0)
                {
                    mainLine_InfoMessage();
                    logCheckBox_HandlerToggle(yLogCheckBox);
                    return;
                }

                mainArea.AxisY.IsLogarithmic = yLogCheckBox.Checked;
            }
        }

        private void logCheckBox_HandlerToggle(CheckBox checkBox)
        {
            checkBox.CheckedChanged -= logCheckBox_CheckedChanged;
            checkBox.Checked = false;
            checkBox.CheckedChanged += logCheckBox_CheckedChanged;
        }

        private bool PointsValid()
        {
            foreach (var series in chart.Series)
            {
                if (series is Cut)
                {
                    foreach (var point in series.Points)
                    {
                        if (point.XValue <= 0 || point.YValues[0] <= 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static void mainLine_InfoMessage()
        {
            MessageBox.Show("На логарифмической шкале возможна интерпретация только положительных значений.",
                string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

		private void minMaxTextBox_TextChanged(object sender, EventArgs e)
        {
	        minMaxPanelHolder.ChangeViewByTextboxes(sender, mainArea);
        }

		#region Cuts
	    private Cut newCut;

        private void chart_MouseDown_Cut(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

			var pointStick = cutMath.CalcStick(MainLine, positionX); //прилипание первой точки

			newCut = createCut();
			newCut.Initialize(chart, cutDetailsPanel, pointStick.XValue, pointStick.YValues[0], pointStick.XValue, pointStick.YValues[0]);
			newCut.Draw(chart);

			newCut.AddToPanel(cutCollectionPanel);

            chart.MouseMove += chart_MouseMove_Cut;
            chart.MouseUp += chart_MouseUp_Cut;
        }

        private void chart_MouseMove_Cut(object sender, MouseEventArgs e)
        {
			if (newCut == null) return;

			var pointStick = cutMath.CalcStick(MainLine, positionX); //прилипание второй точки по ходу движения

			newCut.ChangeRightPoint(pointStick.XValue, pointStick.YValues[0]);
			newCut.Draw(chart);
        }

        private void chart_MouseUp_Cut(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
			if (newCut == null) return;

			var pointStick = cutMath.CalcStick(MainLine, positionX); //прилипание второй точки

			newCut.ChangeRightPoint(pointStick.XValue, pointStick.YValues[0]);

			newCut.Draw(chart);

			newCut = null;

            chart.MouseMove -= chart_MouseMove_Cut;
            chart.MouseUp -= chart_MouseUp_Cut;
        }

        private void xTextBox_TextChanged(object sender, EventArgs e)
        {
			var xTextBox = sender as TextBox;
			if (xTextBox == null) return;
            
			if (xTextBox.Text.Length > 20) xTextBox.Text = string.Empty;

            double value, x1, x2;

            if (double.TryParse(xTextBox.Text, out value))
            {
                if ((mainArea.AxisX.IsLogarithmic || mainArea.AxisY.IsLogarithmic) && value <= 0)
                {
                    cut_InfoMessage();
                    return;
                }
            }

            if (double.TryParse(x1TextBox.Text, out x1) && double.TryParse(x2TextBox.Text, out x2))
            {
				var currentCut = cutDetailsPanel.Tag as Cut;
				if (currentCut == null) return;

	            if (xTextBox == x1TextBox)
	            {
					currentCut.ChangeLeftPoint(x1, cutMath.CalcStick(MainLine, x1).YValues[0]);
				}
				else if (xTextBox == x2TextBox)
				{
					currentCut.ChangeRightPoint(x2, cutMath.CalcStick(MainLine, x2).YValues[0]);
				}
            }
            else
            {
				cutInfoPanelHolder.ClearPanel();
            }
        }

        private static void cut_InfoMessage()
        {
            MessageBox.Show("На логарифмической шкале возможна интерпретация только отрезков с положительными значениями.",
                        string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

		private void buttonToExcel_Click(object sender, EventArgs e)
		{
			excel.Export(chart);
		}
    }
}
