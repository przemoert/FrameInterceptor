using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameInterceptor.Utils;

namespace FrameInterceptor.CustomControls
{
    public partial class TypeAreaUC : UserControl
    {
        public event EventHandler<TypeAreaEventArgs> ButtonClicked;
        public event EventHandler CheckedChanged;

        public bool SendCheckboxVisible { get => this.chkSend.Visible; set => this.chkSend.Visible = value; }
        public bool SendCheckboxChecked { get => this.chkSend.Checked; }

        public TypeAreaUC()
        {
            InitializeComponent();

            this.SubscripteControls();
        }

        private void SubscripteControls()
        {
            foreach (Control control in this.groupBox4.Controls)
            {
                if (control is Button b)
                {
                    b.Click -= new EventHandler(this.OnButtonClick);
                    b.Click += new EventHandler(this.OnButtonClick);
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            TypeAreaEventArgs l_Args = new TypeAreaEventArgs(sender);

            this.ButtonClicked?.Invoke(this, l_Args);
        }

        protected override void OnResize(EventArgs e)
        {
            return;
        }

        private void chkSend_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckedChanged?.Invoke(this, e);
        }
    }
}
