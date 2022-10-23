using System.Runtime.InteropServices;
using System.Drawing;

namespace OSRSBadBot
{
    public class Program
    {
        public Program() { }

        public static void Main()
        {
            Window window = new Window("Old School RuneScape");
            ImageDetectionManager imageDetectionManager = new ImageDetectionManager();
            if (window.CheckForWindowOpen())
            {
                window.SetWindowToWindowDimensions();
                Console.WriteLine("Bot initializing... happy botting!");
                Rectangle resizeTo = new Rectangle(10, 10, 1280, 720);
                window.ResizeWindowDimensions(resizeTo);
                Bitmap test = window.GetMostRecentScreenshot();
                window.TestBitmapOutputToFile(test);

                //console logs any text detected in bitmap
                imageDetectionManager.ScanBitmapForText("c:\\Users\\hunter\\Pictures\\tesseract.png");
                //while (true)
                //{

                //    //Update();

                //    /*notes for future development
                //    --- every frame/iteration ---
                //    1. take screenshot of application
                //    2. Make changes to screen shot of analysis purposes. i.e change to bmp/png etc.
                //    3. analyze updated screenshot based on bot functionality
                //    4. apply logic based on state
                //    5. input user response
                //    */

                //}
            }
        }

        private static void Update()
        {
            Console.WriteLine("do this every frame");
        }

        private static void OnExit()
        {
            Console.WriteLine("Closing Bad Bot");
        }
    }
}

