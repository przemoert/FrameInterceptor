using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;

namespace FrameInterceptor.CustomControls
{
    public partial class InputFiled : UserControl
    {
        public event EventHandler TextHasChanged;

        public enum ValidationMode { None, Numeric, TcpPort, IPAddress, Domain, IpAndDomain }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private ValidationMode _validationType;
        public ValidationMode ValidationType { get => this._validationType; set => this._validationType = value; }

        public string Title { get => this.groupBox1.Text; set => this.groupBox1.Text = value; }
        public new bool Enabled { get => this.textBox1.Enabled; set => this.textBox1.Enabled = value; }
        public new Color BackColor { get => this.textBox1.BackColor; set => this.textBox1.BackColor = value; }
        public bool ReadOnly { get => this.textBox1.ReadOnly; set => this.textBox1.ReadOnly = value; }
        public HorizontalAlignment TextAlign { get => this.textBox1.TextAlign; set => this.textBox1.TextAlign = value; }
        public bool IsValid
        {
            get
            {
                if (this._validationType == ValidationMode.None)
                {
                    return true;
                }
                else if (this._validationType == ValidationMode.Numeric)
                {
                    return Int32.TryParse(this.textBox1.Text, out _);
                }
                else if (this._validationType == ValidationMode.TcpPort)
                {
                    int l_Port = 0;

                    if (!Int32.TryParse(this.textBox1.Text, out l_Port))
                        return false;

                    if (!this.ValidateTcpPort(l_Port))
                        return false;
                }
                else if (this._validationType == ValidationMode.IPAddress)
                {
                    return Validation.ValidateIp(this.textBox1.Text);
                }
                else if (this._validationType == ValidationMode.Domain)
                {
                    return Validation.ValidateDomain(this.textBox1.Text);
                }
                else if (this._validationType == ValidationMode.IpAndDomain)
                    return Validation.ValidateIp(this.textBox1.Text) && Validation.ValidateDomain(this.textBox1.Text);

                return true;
            }
        }

        public InputFiled()
        {
            InitializeComponent();

            this.MaximumSize = new Size(500, this.textBox1.Height + this.textBox1.Location.Y + 5);
            this.MinimumSize = new Size(20, this.textBox1.Height + this.textBox1.Location.Y + 5);
        }

        private bool ValidateTcpPort(int iPort)
        {
            return iPort > 0 && iPort <= 65535;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.TextHasChanged?.Invoke(this, e);
        }
    }
}
