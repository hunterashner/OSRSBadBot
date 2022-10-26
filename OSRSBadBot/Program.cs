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
            Player player = new Player();

            if (window.CheckForWindowOpen())
            {
                window.SetWindowToWindowDimensions();
                Console.WriteLine("Bot initializing... happy botting!");
                Rectangle resizeTo = new Rectangle(10, 10, 1280, 720);
                window.ResizeWindowDimensions(resizeTo);

                System.Threading.Thread.Sleep(1000);
                Bitmap screenshot = window.GetMostRecentScreenshot();

                // logic for selecting current script // await user input for selected script

                //if combat script selected look to do this on steady interval
                player.CombatCheck(screenshot);

                player.AttackTargetEnemy(screenshot, null);

                //    /*notes for future development
                //    --- every frame/iteration ---
                //    1. take screenshot of application
                //    2. Make changes to screen shot of analysis purposes. i.e change to bmp/png etc.
                //    3. analyze updated screenshot based on bot functionality
                //    4. apply logic based on state
                //    5. input user response
            }
        }
    }
}

