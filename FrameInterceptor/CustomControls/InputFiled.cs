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

        public InputFiled()
        {
            InitializeComponent();

            this.MaximumSize = new Size(500, this.textBox1.Height + this.textBox1.Location.Y + 5);
            this.MinimumSize = new Size(20, this.textBox1.Height + this.textBox1.Location.Y + 5);
        }
    }
}
