using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OSRSBadBot
{
    internal class Window
    {
        public IntPtr Ptr { get; set; }
        public string Name { get; private set; }
        public Rectangle Proportions { get; private set; }
        
        public Window(string name) 
        { 
            Name = name;
            Ptr = IntPtr.Zero;
            Proportions = new Rectangle();
        }

        public bool CheckForWindowOpen()
        {
            IntPtr nullCheck = WindowHelpers.GetHandleWindow(Name);
            if (nullCheck == IntPtr.Zero)
            {
                Console.WriteLine("Please open the OSRS client and try again.");
                return false;
            }
            else
            {
                this.Ptr = nullCheck;
                return true;
            }
        }

        public void SetWindowToWindowDimensions()
        {
            Proportions = WindowHelpers.GetHandleWindowRect(Ptr, Proportions);
            Console.WriteLine(Proportions);
        }

        public Bitmap GetMostRecentScreenshot()
        {
            return WindowHelpers.GetHandlePrintWindow(Ptr, Proportions);
        }

        public void TestBitmapOutputToFile(Bitmap bmp)
        {
            bmp.Save("c:\\Users\\hunter\\Pictures\\testing.bmp");
        }

        public void ResizeWindowDimensions(Rectangle rectangle)
        {
            WindowHelpers.GetHandleMoveWindow(Ptr, rectangle);
        }
    }
}
