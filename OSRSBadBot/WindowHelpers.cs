using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

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
