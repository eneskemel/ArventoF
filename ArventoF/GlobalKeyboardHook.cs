using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _134KO
{
    public class GlobalKeyboardHook
    {
		const int WH_KEYBOARD_LL = 13;
		const int WM_KEYDOWN = 0x100;
		const int WM_KEYUP = 0x101;
		const int WM_SYSKEYDOWN = 0x104;
		const int WM_SYSKEYUP = 0x105;

		public List<Keys> HookedKeys = new List<Keys>();
		IntPtr hhook = IntPtr.Zero;
        private Win32.keyboardHookProc hookProcDelegate;

		public event KeyEventHandler KeyDown;
		public event KeyEventHandler KeyUp;

		public GlobalKeyboardHook() {
            hookProcDelegate = hookProc;
			hook();
		}

		~GlobalKeyboardHook() {
			unhook();
		}

		public void hook() {
			IntPtr hInstance = Win32.LoadLibrary("User32");
            hhook = Win32.SetWindowsHookEx(WH_KEYBOARD_LL, hookProcDelegate, hInstance, 0);
		}

		public void unhook() {
            Win32.UnhookWindowsHookEx(hhook);
		}

        public int hookProc(int code, int wParam, ref Win32.keyboardHookStruct lParam)
        {
			if (code >= 0) {
				Keys key = (Keys)lParam.vkCode;
				if (HookedKeys.Contains(key)) {
					KeyEventArgs kea = new KeyEventArgs(key);
					if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null)) {
						KeyDown(this, kea) ;
					} else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null)) {
						KeyUp(this, kea);
					}
					if (kea.Handled)
						return 1;
				}
			}
            return Win32.CallNextHookEx(hhook, code, wParam, ref lParam);
		}
    }
}
