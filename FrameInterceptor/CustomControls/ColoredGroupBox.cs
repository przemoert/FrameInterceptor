using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameInterceptor.CustomControls
{
    public class ColoredGroupBox : GroupBox
    {
        private Color _borderColor = Color.White;
        private Color _textColor = Color.White;

        public Color BorderColor
        {
            get => this._borderColor;
            set
            {
                this._borderColor = value;
                this.Invalidate();
            }
        }
        public Color TextColor
        {
            get => this._textColor;
            set
            {
                this._textColor = value;
                this.Invalidate();
            }
        }

        public ColoredGroupBox() : base() { }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics l_Graphics = e.Graphics;

            Brush l_TextBrush = new SolidBrush(this._textColor);
            Brush l_BorderBrush = new SolidBrush(this._borderColor);
            Pen l_BorderPen = new Pen(l_BorderBrush);
            
            SizeF l_TextSize = l_Graphics.MeasureString(this.Text, this.Font);

            Rectangle l_Rectangle = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y + (int)(l_TextSize.Height / 2), this.ClientRectangle.Width - 1, this.ClientRectangle.Height - (int)(l_TextSize.Height / 2) - 1);

            l_Graphics.Clear(this.BackColor);

            l_Graphics.DrawString(this.Text, this.Font, l_TextBrush, this.Padding.Left, 0);

            // Drawing Border
            //Left
            l_Graphics.DrawLine(l_BorderPen, l_Rectangle.Location, new Point(l_Rectangle.X, l_Rectangle.Y + l_Rectangle.Height));
            //Right
            l_Graphics.DrawLine(l_BorderPen, new Point(l_Rectangle.X + l_Rectangle.Width, l_Rectangle.Y), new Point(l_Rectangle.X + l_Rectangle.Width, l_Rectangle.Y + l_Rectangle.Height));
            //Bottom
            l_Graphics.DrawLine(l_BorderPen, new Point(l_Rectangle.X, l_Rectangle.Y + l_Rectangle.Height), new Point(l_Rectangle.X + l_Rectangle.Width, l_Rectangle.Y + l_Rectangle.Height));
            //Top1
            l_Graphics.DrawLine(l_BorderPen, new Point(l_Rectangle.X, l_Rectangle.Y), new Point(l_Rectangle.X + this.Padding.Left, l_Rectangle.Y));
            //Top2
            l_Graphics.DrawLine(l_BorderPen, new Point(l_Rectangle.X + this.Padding.Left + (int)(l_TextSize.Width), l_Rectangle.Y), new Point(l_Rectangle.X + l_Rectangle.Width, l_Rectangle.Y));

            //base.OnPaint(e);
        }
    }
}
