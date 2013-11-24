﻿using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplicationChart
{
    public partial class MainForm : Form
    {
        private Line mainLine;
        private ChartArea mainArea;
        private double positionX;
        private double positionY;

        public MainForm()
        {
            InitializeComponent();
            Load += mainForm_Load;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            mainForm_SizeChanged(this, new EventArgs());
            mainLine = new Line();
            mainArea = chart.ChartAreas[0];
        }

        private void chart_Reset()
        {
            cutCollectionPanel.Controls.Clear();
            Cut.EraseAll(chart);
            Cut.DetailsPanelClear(cutDetailsPanel);

            mainLine.Points.Clear();

            chart.MouseMove -= chart_MouseMove;
            chart.MouseDown -= chart_MouseDown_Cut;
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            var data = Data.Load();
            if (data == null || data.Count <= 0) return;

            chart_Reset();

            mainLine = new Line(data[0]);
            mainLine.Draw(chart);

            mainArea_Set();
            mainArea_Reset();

            for (var i = 1; i < data.Count; i++)
            {
                var current = new Cut(data[i]);
                current.Draw(chart);
                current.DetailsPanel = cutDetailsPanel;
                current.AddToPanel(cutCollectionPanel);
            }

            minMaxPanel_Set();
            zoom_Set();

            chart.MouseMove += chart_MouseMove;
            chart.MouseDown += chart_MouseDown_Cut;
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            Data.Save(chart);
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            cutCollectionPanel.Height = cutsPanel.Height - cutDetailsPanel.Height - 10;
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            mainArea.CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
            mainArea.CursorY.SetCursorPixelPosition(new Point(e.X, e.Y), true);

            positionX = mainArea.CursorX.Position;
            positionY = mainArea.CursorY.Position;

            mousePositionLabel.Text = string.Concat("X = ", positionX, "; Y = ", positionY);
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

                minMaxPanel_Set();
                mainArea_Set();
                zoom_Set();
            }

            if (string.CompareOrdinal(logCheckBox.Name, "xLogCheckBox") == 0)
            {
                if (mainLine.Points[0].XValue <= 0)
                {
                    mainLine_InfoMessage();
                    logCheckBox_HandlerToggle(xLogCheckBox);
                    return;
                }

                mainArea.AxisX.IsLogarithmic = xLogCheckBox.Checked;
            }

            if (string.CompareOrdinal(logCheckBox.Name, "yLogCheckBox") == 0)
            {
                var minY = mainLine.Points[0].YValues[0];
                foreach (var point in mainLine.Points)
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

        #region MinMaxPanel
        private void minMaxPanel_Set()
        {
            minMaxPanel_Reset();

            foreach (var control in minMaxPanel.Controls)
                if (control is TextBox)
                    (control as TextBox).TextChanged += minMaxTextBox_TextChanged;
        }

        private void minMaxPanel_Reset()
        {
            xMinTextBox.Text = string.Empty;
            xMaxTextBox.Text = string.Empty;
            yMinTextBox.Text = string.Empty;
            yMaxTextBox.Text = string.Empty;
        }

        private void minMaxTextBox_TextChanged(object sender, EventArgs e)
        {
			var minMaxTextBox = sender as TextBox;
			if (minMaxTextBox == null) return;

            if (minMaxTextBox.Text.Length > 20) minMaxTextBox.Text = string.Empty;

            double xmin, xmax, ymin, ymax;

            if (double.TryParse(xMinTextBox.Text, out xmin))
            {
                if (!mainArea.AxisX.IsLogarithmic || (mainArea.AxisX.IsLogarithmic && xmin > 0))
                {
                    if (xmin < mainArea.AxisX.Maximum)
                    {
                        mainArea.AxisX.Minimum = xmin;
                    }
                }
            }

            if (double.TryParse(xMaxTextBox.Text, out xmax))
            {
                if (!mainArea.AxisX.IsLogarithmic || (mainArea.AxisX.IsLogarithmic && xmax > 0))
                {
                    if (xmax > mainArea.AxisX.Minimum)
                    {
                        mainArea.AxisX.Maximum = xmax;
                    }
                }
            }

            if (double.TryParse(yMinTextBox.Text, out ymin))
            {
                if (!mainArea.AxisY.IsLogarithmic || (mainArea.AxisY.IsLogarithmic && ymin > 0))
                {
                    if (ymin < mainArea.AxisY.Maximum)
                    {
                        mainArea.AxisY.Minimum = ymin;
                    }
                }
            }

            if (double.TryParse(yMaxTextBox.Text, out ymax))
            {
                if (!mainArea.AxisY.IsLogarithmic || (mainArea.AxisY.IsLogarithmic && ymax > 0))
                {
                    if (ymax > mainArea.AxisY.Minimum)
                    {
                        mainArea.AxisY.Maximum = ymax;
                    }
                }
            }
        }
        #endregion

        #region Cuts
        private Cut cut;
        private void chart_MouseDown_Cut(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (mainArea.AxisX.IsLogarithmic || mainArea.AxisY.IsLogarithmic)
            {
                MessageBox.Show("На логарифмической шкале не возможно построение отрезков.",
                    string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var point = new DataPoint(positionX, positionY);
            var pointStick = Cut.CalcStick(mainLine, point); //прилипание первой точки

            cut = new Cut(pointStick.XValue, pointStick.YValues[0], pointStick.XValue, pointStick.YValues[0]);
            cut.Draw(chart);

            chart.MouseMove += chart_MouseMove_Cut;
            chart.MouseUp += chart_MouseUp_Cut;
        }

        private void chart_MouseMove_Cut(object sender, MouseEventArgs e)
        {
            if (cut == null) return;

            var point = new DataPoint(positionX, positionY);

            cut.Erase();
            cut.X2 = point.XValue;
            cut.Draw(chart);
        }

        private void chart_MouseUp_Cut(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (cut == null) return;

            var point = new DataPoint(positionX, positionY);
            var pointStick = Cut.CalcStick(mainLine, point); //прилипание второй точки

            cut.X2 = pointStick.XValue;
            cut.Y2 = pointStick.YValues[0];

            cut.Erase();
            cut.Draw(chart);
            cut.DetailsPanel = cutDetailsPanel;
            cut.AddToPanel(cutCollectionPanel);

            cut = null;

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

                if (string.CompareOrdinal(xTextBox.Name, "x1TextBox") == 0) currentCut.X1 = x1;
                if (string.CompareOrdinal(xTextBox.Name, "x2TextBox") == 0) currentCut.X2 = x2;

                lenghtLabel.Text = currentCut.Lenght.ToString();
                slopeLabel.Text = currentCut.Area.ToString();
                areaLabel.Text = currentCut.Slope.ToString();
            }
            else
            {
                lenghtLabel.Text = 0.ToString();
                slopeLabel.Text = 0.ToString();
                areaLabel.Text = 0.ToString();
            }
        }

        private static void cut_InfoMessage()
        {
            MessageBox.Show("На логарифмической шкале возможна интерпретация только отрезков с положительными значениями.",
                        string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
