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
    }
}
