using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bar
{

    public partial class bar : UserControl
    {
        private List<float> values = new List<float>();
        private List<string> labels = new List<string>();

        public bar()
        {
            InitializeComponent();
        }
        public void set(List<float> data, List<string> labelNames = null)
        {
            values = data;
            labels = labelNames ?? new List<string>(data.Count);
            Invalidate(); // Force a redraw
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            // Avoid divide by zero if the list is empty
            if (values == null || values.Count == 0)
                return;
            int chartHeight = Height - 40;
            int chartWidth = Width - 40;
            int barWidth = chartWidth / values.Count - 20;
            float maxAbsValue = values.Max(v => Math.Abs(v));
            float scale = chartHeight / (2 * maxAbsValue);
            Label l= new Label();
           
            l.Location=new Point(640,-5);
            l.Visible = true;
            this.Controls.Add(l);
            
            // Calculate Y-axis center (where Y = 0)
            int yAxisCenter = (int)(Height / 2);
            g.DrawLine(Pens.Black,50, 0, 50, Height);
             // Draw the X-axis at yAxisCenter
            g.DrawLine(Pens.Black, 50, yAxisCenter, Width, yAxisCenter);
            for (int i = 0; i < values.Count; i++)
            {
                float value = values[i];
                Color barColor = Color.FromArgb(255, (i * 50) % 255, (i * 80) % 255, (i * 120) % 255);
                Brush brush = new SolidBrush(barColor);
                //calculating the bar height
                int barHeight = (int)(Math.Abs(value) * scale);
                int x = 60 + i * (barWidth + 10);
                //finding the bar height if the value is positive or negative
                int y = value >= 0 ? (yAxisCenter - barHeight) : yAxisCenter;
                g.FillRectangle(brush, x, y, barWidth, barHeight);
                //labels for the bars 
                g.DrawString(labels[i], Font, Brushes.Black, x + barWidth / 4, Height - 20);
            }

            // Y-axis labels for positive and negative values
            for (int i = -5; i <= 5; i++)  
            {
                float labelValue = maxAbsValue * i / 5;
                int y= (int)(yAxisCenter - labelValue * scale);
                g.DrawString(labelValue.ToString("0.0"), Font, Brushes.Black, 3, y - Font.Height / 2);
            }
            l.Text = "Scale:" + scale.ToString();
        }
    }
}
