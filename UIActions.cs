using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcyon
{
    internal class UIActions
    {
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        public void CloseApp()
        {
            Application.Exit();
        }
        public void MinimizeApp(Form form)
        {
            form.WindowState = FormWindowState.Minimized;
        }
        public void MaximizeApp(Form form)
        {
            form.WindowState = FormWindowState.Maximized;
        }
        public void MoveApp(object sender, MouseEventArgs e, Form form)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
