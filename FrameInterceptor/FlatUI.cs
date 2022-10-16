using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameInterceptor
{
    public partial class FlatUI : Form
    {
        #region MakingMovable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region FromEvents

        private void OnTaskButtonClick(object sender, EventArgs e)
        {
            Button l_Button = (Button)sender;

            if (l_Button.Name == "btnFormClose")
            {
                this.Close();
            }
            else if (l_Button.Name == "btnFormMaximize")
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
            else if (l_Button.Name == "btnFormMinimize")
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void OnMenuButtonClick(object sender, EventArgs e)
        {
            Button l_Button = (Button)sender;

            this.HideConnectionSettings();

            if (l_Button.Name == "btnSerialForm")
            {
                this.ShowSerial();
            }
            else if (l_Button.Name == "btnServerForm")
            {
                this.ShowServer();
            }
            else if (l_Button.Name == "btnClientForm")
            {
                this.ShowClient();
            }
        }

        #endregion

        #region FormEventHelpers

        private void HidePanels()
        {
            this.panLogsTop.Visible = false;
            this.panLogsBottom.Visible = false;
            this.panSerialSettings.Visible = false;
            this.panClientSettings.Visible = false;
            this.panServerSettings.Visible = false;
        }

        private void HideConnectionSettings()
        {
            this.panSerialSettings.Visible = false;
            this.panClientSettings.Visible = false;
            this.panServerSettings.Visible = false;
        }

        private void HideLogs()
        {
            this.panLogsTop.Visible = false;
            this.panLogsBottom.Visible = false;
        }

        private void ShowLogs()
        {
            this.panLogsTop.Visible = true;
            this.panLogsBottom.Visible = true;
        }

        private void ShowSerial()
        {
            this.panSerialSettings.Visible = true;
        }

        private void ShowClient()
        {
            this.panClientSettings.Visible = true;
        }

        private void ShowServer()
        {
            this.panServerSettings.Visible = true;
        }

        #endregion

        #region UISettings

        private void SetupControls()
        {
            this.HideConnectionSettings();

            this.panSerialSettings.Dock = DockStyle.Fill;
            this.panServerSettings.Dock = DockStyle.Fill;
            this.panClientSettings.Dock = DockStyle.Fill;
        }

        #endregion

        public FlatUI()
        {
            InitializeComponent();

            this.SetupControls();
        }

        
    }
}
