using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameInterceptor.CustomControls
{
    public partial class InputFiled : UserControl
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string Title { get => this.groupBox1.Text; set => this.groupBox1.Text = value; }

        public new bool Enabled { get => this.textBox1.Enabled; set => this.textBox1.Enabled = value; }
        public new Color BackColor { get => this.textBox1.BackColor; set => this.textBox1.BackColor = value; }
        public bool ReadOnly { get => this.textBox1.ReadOnly; set => this.textBox1.ReadOnly = value; }
        public HorizontalAlignment TextAlign { get => this.textBox1.TextAlign; set => this.textBox1.TextAlign = value; }

        public InputFiled()
        {
            InitializeComponent();

            this.MaximumSize = new Size(500, this.textBox1.Height + this.textBox1.Location.Y + 5);
            this.MinimumSize = new Size(20, this.textBox1.Height + this.textBox1.Location.Y + 5);
        }
    }
}
