using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameInterceptor.CustomControls
{
    public class TranslatedTextBox : TextBox
    {
        public bool TranslateControlChars { get; set; } = false;

        public override string Text
        {
            get
            {
                if (this.TranslateControlChars)
                {
                    return ControlChars.ReplaceControlCharsReversed(base.Text);
                }

                return base.Text;
            }
            set
            {
                base.OnTextChanged(EventArgs.Empty);
            }
        }

        protected override void WndProc(ref Message m)
        {
            //We have to override paste event, because of textbox ignores some special characters. Not sure about CodePage - needs tests.
            if (m.Msg == 0x302 && Clipboard.ContainsText())
            {
                byte[] test = Encoding.UTF8.GetBytes(Clipboard.GetText());

                this.SelectedText = Clipboard.GetText();
                return;
            }

            base.WndProc(ref m);
        }
    }
}
