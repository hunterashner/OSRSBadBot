using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OSRSBadBot
{
    internal class WindowHelpers
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern long GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        //not working correctly on W11, will try to add functionality through directX
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        public static void SendLeftclickDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 50, 50, 0, UIntPtr.Zero);
        }

        public static void SendLeftclickUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 50, 50, 0, UIntPtr.Zero);
        }

        public static void SendCursorToPosition(Vector2 position)
        {
            SetCursorPos((int)position.X, (int)position.Y);       
        }

        public static IntPtr GetHandleWindow(string title)
        {
            return FindWindow(null, title);
        }

        public static Rectangle GetHandleWindowRect(IntPtr window, Rectangle rectangle)
        {
            Rectangle rect;
            GetWindowRect(window, ref rectangle);
            rect = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            return rect;
        }

        public static Bitmap GetHandlePrintWindow(IntPtr hWnd, Rectangle rect)
        {
            GetHandleWindowRect(hWnd, rect);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gfx = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfx.GetHdc();

            //3rd parameter nFlags (only worked with 2 - not sure why... )
            PrintWindow(hWnd, hdcBitmap, 2);
            gfx.ReleaseHdc(hdcBitmap);
            gfx.Dispose();

            return bmp;
        }

        //repaint window at pointer to rectangle parameter
        public static void GetHandleMoveWindow(IntPtr window, Rectangle dimensions)
        {
            MoveWindow(window, dimensions.X, dimensions.Y, dimensions.Width, dimensions.Height, true);
        }
    }
}
