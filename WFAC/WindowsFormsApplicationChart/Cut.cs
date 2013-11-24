using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplicationChart
{
    class Cut : CutBase
    {
        #region Fields
        private double _x1;
        private double _x2;
        private double _y1;
        private double _y2;
        #endregion

        #region Constructors
        public Cut(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public Cut(List<DataPoint> points)
        {
            X1 = (points)[0].XValue;
            Y1 = (points)[0].YValues[0];
            X2 = (points)[1].XValue;
            Y2 = (points)[1].YValues[0];
        }
        #endregion

        #region Properties
        public double X1
        {
            get { return _x1; }
            set
            {
                _x1 = value;
                ChangeItems();
            }
        }

        public double X2
        {
            get { return _x2; }
            set
            {
                _x2 = value;
                ChangeItems();
            }
        }

        public double Y1
        {
            get { return _y1; }
            set
            {
                _y1 = value;
                ChangeItems();
            }
        }

        public double Y2
        {
            get { return _y2; }
            set
            {
                _y2 = value;
                ChangeItems();
            }
        }

        public double Lenght { get; private set; }

        public double Area { get; private set; }

        public double Slope { get; private set; }

        public Chart ParentChart { get; private set; }

        public Panel DetailsPanel { get; set; }
        #endregion

        private void ChangeItems()
        {
            Points.Clear();
            Points.Add(new DataPoint(X1, Y1));
            Points.Add(new DataPoint(X2, Y2));

            Lenght = MathLength();
            Area = MathArea();
            Slope = MathSlope();
        }

        #region Math
        private double MathLength()
        {
	        return Math.Abs(X2 - X1);
        }

        private double MathArea()
        {
            return 0;
        }

        private double MathSlope()
        {
	        if (Math.Abs(X1 - X2) < 1e-10)
				return Y2 >= Y1 ? double.PositiveInfinity : double.NegativeInfinity;

	        return (Y2 - Y1) / (X2 - X1);
        }
        #endregion

        #region Draw & Erase & Stick
        public void Draw(Chart chart)
        {
            ParentChart = chart;
            Erase();
            chart.Series.Add(this);
        }

        public void Erase()
        {
            if (ParentChart.Series.IndexOf(this) > -1) ParentChart.Series.Remove(this);
        }

        public static void EraseAll(Chart chart)
        {
            chart.Series.Clear();
        }

		/// <summary>
		/// прилипание
		/// </summary>
		/// <param name="line">основная линия графика</param>
		/// <param name="chartX">точка позиции курсора мыши в координатах графика</param>
        public static DataPoint CalcStick(Line line, double chartX)
		{
			var leftRight = line.GetLeftRight(chartX);

			var lx = leftRight.Item1.XValue;
			var ly = leftRight.Item1.YValues[0];
			var rx = leftRight.Item2.XValue;
			var ry = leftRight.Item2.YValues[0];
			var x = chartX;

			var y = ly + (x - lx) / (rx - lx) * (ry - ly);

			return new DataPoint(x, y);
		}

        #endregion

        #region Add & Remove
        public void AddToPanel(Panel panel)
        {
            var cutPanel = new Panel
            {
                Width = 170,
                Height = 20
            };

            var removeLabel = new Label
            {
                Text = "x",
                Width = 10,
                ForeColor = Color.DarkRed,
                Font = new Font(Font, Font.Style | FontStyle.Bold),
                Location = new Point(155, 3),
                Cursor = Cursors.Hand
            };
            removeLabel.MouseDown += removeLabel_MouseDown;
            cutPanel.Controls.Add(removeLabel);

            var cutLabel = new Label
            {
                Width = 160,
                Location = new Point(3, 3)
            };
            cutLabel.MouseDown += cutLabel_MouseDown;
            cutPanel.Controls.Add(cutLabel);

            panel.Controls.Add(cutPanel);
            ChangePanel(panel);

            cutLabel_MouseDown(cutLabel, null);
        }

        private void RemoveFromPanel(Panel cutCollectionPanel, Panel cutPanel)
        {
            if (ParentChart == null) return;

            Erase();
            DetailsPanel.Tag = null;
            cutCollectionPanel.Controls.Remove(cutPanel);
            ChangePanel(cutCollectionPanel);
        }

        private static void ChangePanel(Panel panel)
        {
            var y = -17;
            var i = 0;
            foreach (Panel control in panel.Controls)
            {
				control.Controls[1].Text = string.Concat("отрезок ", (++i).ToString());
                control.Location = new Point(3, y += 20);
            }
        }

        public static void DetailsPanelClear(Panel panel)
        {
            panel.Controls["x1TextBox"].Text = 0.ToString();
            panel.Controls["x2TextBox"].Text = 0.ToString();
            panel.Controls["lenghtLabel"].Text = 0.ToString();
            panel.Controls["slopeLabel"].Text = 0.ToString();
            panel.Controls["areaLabel"].Text = 0.ToString();
        }

        private void cutLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

			var cutPanel = (Panel)((Control)sender).Parent;
			var cutCollectionPanel = (Panel)cutPanel.Parent;

            foreach (Panel p in cutCollectionPanel.Controls)
            {
                p.BackColor = Color.Transparent;
            }

            cutPanel.BackColor = Color.LightBlue;

            foreach (var series in ParentChart.Series)
            {
                if (series is Cut)
                {
                    (series as Cut).BorderWidth = 2;
                }
            }

            BorderWidth = 4;

            DetailsPanel.Tag = this;
            DetailsPanel.Controls["x1TextBox"].Text = X1.ToString();
            DetailsPanel.Controls["x2TextBox"].Text = X2.ToString();
            DetailsPanel.Controls["lenghtLabel"].Text = Lenght.ToString();
            DetailsPanel.Controls["slopeLabel"].Text = Slope.ToString();
            DetailsPanel.Controls["areaLabel"].Text = Area.ToString();
        }

        private void removeLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

			var cutPanel = (Panel)((Control)sender).Parent;
			var cutCollectionPanel = (Panel)cutPanel.Parent;
            RemoveFromPanel(cutCollectionPanel, cutPanel);
        }
        #endregion
    }
}
