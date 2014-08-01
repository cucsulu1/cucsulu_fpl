using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClickWebbrowser
{
    public class WinUtilities
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        #region Constants
        //Finds a window by class name
        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //Sets a window to be a child window of another window
        [DllImport("USER32.DLL")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //Sets window attributes
        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //Gets window attributes
        [DllImport("USER32.DLL")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("user32.dll")]
        public static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern int SetWindowText(IntPtr hWnd, string text);


        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        //assorted constants needed
        public static uint MF_BYPOSITION = 0x400;
        public static uint MF_REMOVE = 0x1000;
        public static int GWL_STYLE = -16;
        public static int WS_CHILD = 0x40000000; //child window
        public static int WS_BORDER = 0x00800000; //window with border
        public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public static int WS_CAPTION = WS_BORDER | WS_DLGFRAME; //window with a title bar 
        public static int WS_SYSMENU = 0x00080000; //window menu  
        
        
        #endregion


        public IntPtr WndHandle { get; set; }
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        public void LeftClick(Point clientPoint)
        {
            var oldPos = Cursor.Position;
            /// get screen coordinates
            ClientToScreen(WndHandle, ref clientPoint);
            /// set cursor on coords, and press mouse
            Cursor.Position = new Point(clientPoint.X, clientPoint.Y);
            mouse_event(0x00000002, 0, 0, 0, UIntPtr.Zero); /// left mouse button down
            mouse_event(0x00000004, 0, 0, 0, UIntPtr.Zero); /// left mouse button up
            /// return mouse 
            Cursor.Position = oldPos;
        }
        //[DllImport("User32.dll")]
        //public static extern int FindWindow(string strClassName, string strWindowName);

        //[DllImport("User32.dll")]
        //public static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string strClassName, string strWindowName);


        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern int SendMessage(IntPtr A_0, int A_1, int A_2, int A_3);

        //static int WM_CLOSE = 0x10;
        //static int WM_LBUTTONDOWN = 0x201;
        //static int WM_LBUTTONUP = 0x202;

        //public static void click(IntPtr hWnd, int x, int y)
        //{
        //    SendMessage(hWnd, WM_LBUTTONDOWN, 1, ((x << 0x10) ^ y));
        //    SendMessage(hWnd, WM_LBUTTONUP, 0, ((x << 0x10) ^ y));
        //}

        // Get a handle to an application window.

        // Activate an application window.


        // Send a series of key presses to the Calculator application. 
        private void button1_Click(object sender, EventArgs e)
        {
            // Get a handle to the Calculator application. The window class 
            // and window name were obtained using the Spy++ tool.
            IntPtr calculatorHandle = FindWindow("CalcFrame", "Calculator");

            // Verify that Calculator is a running process. 
            if (calculatorHandle == IntPtr.Zero)
            {
                MessageBox.Show("Calculator is not running.");
                return;
            }

            // Make Calculator the foreground application and send it  
            // a set of calculations.
            SetForegroundWindow(calculatorHandle);
            SendKeys.SendWait("111");
            SendKeys.SendWait("*");
            SendKeys.SendWait("11");
            SendKeys.SendWait("=");


            //SetCursorPos(action.X, action.Y);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */

                [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);
        [DllImport("user32.dll",
            CharSet = CharSet.Auto,CallingConvention=CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons,
            int dwExtraInfo);
    }
}
