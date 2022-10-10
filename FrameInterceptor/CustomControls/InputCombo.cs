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
    public partial class InputCombo : UserControl
    {        
        public string Title { get => this.groupBox1.Text; set => this.groupBox1.Text = value; }
        public object DataSource { get => this.comboBox1.DataSource; set => this.comboBox1.DataSource = value; }
        public object Value { get => this.comboBox1.SelectedItem; }
        public int SelectedIndex { get => this.comboBox1.SelectedIndex; set => this.comboBox1.SelectedIndex = value; }
        public int Count { get => this.comboBox1.Items.Count; }

        public InputCombo()
        {
            InitializeComponent();

            this.MaximumSize = new Size(500, this.comboBox1.Height + this.comboBox1.Location.Y + 5);
            this.MinimumSize = new Size(20, this.comboBox1.Height + this.comboBox1.Location.Y + 5);
        }
    }
}
