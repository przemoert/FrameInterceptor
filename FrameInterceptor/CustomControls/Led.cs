using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameInterceptor.CustomControls
{
    public partial class Led : UserControl
    {
        private Color _greenColor;
        private Color _redColor;
        private bool _on = true;

        public bool On
        {
            get => this._on;
            set
            {
                this._on = value;
                this.Invalidate();
            }
        }

        public Led()
        {
            SetStyle(ControlStyles.DoubleBuffer
            | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.ResizeRedraw
            | ControlStyles.UserPaint
            | ControlStyles.SupportsTransparentBackColor, true);

            this._greenColor = Color.FromArgb(255, 51, 102, 02);
            this._redColor = Color.FromArgb(255, 204, 0, 0);
            this.Width = 20;
            this.Height = 20;
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.Width != this.Height)
            {
                this.Width = this.Height;
                this.Height = this.Width;
            }

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Create an offscreen graphics object for double buffering
            Bitmap offScreenBmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (System.Drawing.Graphics g = Graphics.FromImage(offScreenBmp))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                // Draw the control
                this.Draw(g);
                // Draw the image to the screen
                e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
            }
        }

        private void Draw(Graphics g)
        {
            Color l_HelperColor = (this._on) ? Color.White : Color.Black;
            Color l_MainColor = (this._on) ? this._greenColor : this._redColor;
            Color l_CenterColor = Color.White;

            int l_Diameter = Math.Min(this.Width, this.Height);
            l_Diameter = Math.Max(l_Diameter - 1, 1);

            Rectangle l_Rect = new Rectangle(0, 0, l_Diameter, l_Diameter);
            g.FillEllipse(new SolidBrush(l_HelperColor), l_Rect);

            GraphicsPath l_Path = new GraphicsPath();
            l_Path.AddEllipse(l_Rect);

            PathGradientBrush l_PathBrush = new PathGradientBrush(l_Path);
            l_PathBrush.CenterColor = l_CenterColor;
            l_PathBrush.SurroundColors = new Color[] { l_MainColor };
            l_PathBrush.FocusScales = new PointF(0.15f, 0.15f);
            g.FillPath(l_PathBrush, l_Path);


            GraphicsPath l_Path1 = new GraphicsPath();
            l_Path1.AddEllipse(l_Rect);

            PathGradientBrush l_PathBrush1 = new PathGradientBrush(l_Path);
            l_PathBrush1.CenterColor = Color.FromArgb(0, l_HelperColor);
            l_PathBrush1.SurroundColors = new Color[] { Color.FromArgb(255, l_HelperColor) };
            l_PathBrush1.FocusScales = new PointF(0.9f, 0.9f);
            g.FillPath(l_PathBrush1, l_Path1);
        }
    }
}
