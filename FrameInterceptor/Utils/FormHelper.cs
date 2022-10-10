using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameInterceptor.Utils
{
    public static class FormHelper
    {
        public static T[] GetAllControls<T>(Control iControl)
        {
            List<T> l_Controls = new List<T>();

            if (iControl is T t)
                l_Controls.Add(t);

            if (iControl.Controls.Count > 0)
            {
                foreach (Control c in iControl.Controls)
                {
                    l_Controls.AddRange(FormHelper.GetAllControls<T>(c));
                }
            }

            return l_Controls.ToArray();
        }
    }
}
