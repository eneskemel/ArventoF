using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using AutoItX3Lib;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace _134KO
{
    public class Functions
    {
        static AutoItX3 aix = new AutoItX3();

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        static Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public static Color GetPixelColor(int x, int y)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, x, y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        public static Color GetPixelColor(IntPtr hwnd, int x, int y)
        {
            IntPtr hdc = Win32.GetDC(hwnd);
            uint pixel = Win32.GetPixel(hdc, x, y);
            Win32.ReleaseDC(hwnd, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF), (int)(pixel & 0x0000FF00) >> 8, (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }

        public static IEnumerable<Control> GetDisableableControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetDisableableControls(ctrl)).Concat(controls).Where(c => c.Tag != null);
        }

        public static IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
        }

        public static void SendKey(String key)
        {
            aix.Send(key);
        }

        public static bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        public static Size GetWindowSize(IntPtr hWnd)
        {
            Win32.RECT pRect;
            Size cSize = new Size();
            Win32.GetWindowRect(hWnd, out pRect);
            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;
            return cSize;
        }

     

        public static Color GetClosestColor(Color color)
        {
            IEnumerable<Color> colors = Enum.GetValues(typeof(KnownColor))
                .Cast<KnownColor>()
                .Select(Color.FromKnownColor);

            Color closest = colors.Aggregate(Color.Black,
                            (accu, curr) =>
                            ColorDiff(color, curr) < ColorDiff(color, accu) ? curr : accu);
            return closest;
        }

        private static int ColorDiff(Color color, Color curr)
        {
            return Math.Abs(color.R - curr.R) + Math.Abs(color.G - curr.G) + Math.Abs(color.B - curr.B);
        }

        public static void Log(String log, Color color)
        {

        }

        public static String RandomString(int length) {
            String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rnd = new Random();
            String str = "";
            for (int i = 0; i < length; i++)
            {
                str += characters[rnd.Next(characters.Length - 1)];   
            }
            return str;
        }
    }
}
