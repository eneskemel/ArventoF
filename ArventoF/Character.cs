using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace _134KO
{
    public class Character
    {
        String windowTitle;
        IntPtr windowHandler;
        int processID;
        IntPtr systemMenu;

        public IntPtr SystemMenu
        {
            get { return systemMenu; }
            set { systemMenu = value; }
        }

        public int ProcessID
        {
            get { return processID; }
            set { processID = value; }
        }

        public IntPtr WindowHandler
        {
            get { return windowHandler; }
            set { windowHandler = value; }
        }

        public String WindowTitle
        {
            get { return windowTitle; }
            set { windowTitle = value; }
        }

        public Character(String windowTitle)
        {
            this.WindowTitle = windowTitle;
        }

        public bool CheckCharacterExists()
        {
            return WindowManager.GetWindowProcessIDByWindowName(this.WindowTitle) > -1;
        }

        public void Initialize()
        {
            this.ProcessID = WindowManager.GetWindowProcessIDByWindowName(this.WindowTitle);
            WindowManager.SetWindowNameByProcessID(this.ProcessID, this.ProcessID.ToString());
            this.WindowTitle = this.ProcessID.ToString();
            this.WindowHandler = WindowManager.GetProcessHandle(this.ProcessID);
            this.SystemMenu = GetSystemMenu();
        }

      
      

        public void BringToFront()
        {
            Win32.SetForegroundWindow(this.WindowHandler);
        }

        public IntPtr GetSystemMenu()
        {
            return Win32.GetSystemMenu(this.WindowHandler, false);
        }

        public void DisableCloseButton()
        {
            Win32.EnableMenuItem(this.SystemMenu, Win32.SC_CLOSE, Win32.MF_BYCOMMAND | Win32.MF_GRAYED);
            Win32.DrawMenuBar(this.SystemMenu);
        }

        public void EnableCloseButton()
        {
            Win32.EnableMenuItem(this.SystemMenu, Win32.SC_CLOSE, Win32.MF_BYCOMMAND | Win32.MF_ENABLED);
            Win32.DrawMenuBar(this.SystemMenu);
        }

        public void MaximizeWindow()
        {
            Win32.ShowWindow(this.WindowHandler, Win32.ShowWindowEnum.Restore);
        }

        public void TopMost(bool topMost)
        {
            if (topMost)
            {
                Win32.SetWindowPos(this.WindowHandler, Win32.HWND_TOPMOST, 0, 0, 0, 0, Win32.SWP_NOMOVE | Win32.SWP_NOSIZE | Win32.SWP_SHOWWINDOW);
            }
            else
            {
                Win32.SetWindowPos(this.WindowHandler, Win32.HWND_NOTOPMOST, 0, 0, 0, 0, Win32.SWP_NOMOVE | Win32.SWP_NOSIZE | Win32.SWP_SHOWWINDOW);
            }
        }
    }
}
