using System.Runtime.InteropServices;
using System.Drawing;
using System.Numerics;

namespace OSRSBadBot
{
    public class Program
    {
        public Program() { }

        public static void Main()
        {
            Window window = new Window("Old School RuneScape");
            Player player = new Player();

            //creating new test enemy for attack inputs
            int tolerance = 90;
            Color chickenBody = new Color();

            //rgb(147, 39, 22) red on head
            Color chickenHead = Color.FromArgb(147, 39, 22);
            Chicken chicken = new Chicken(chickenHead, "chicken");

            List<Vector2> closeProxEnemies = new List<Vector2>();

            if (window.CheckForWindowOpen())
            {
                window.SetWindowToWindowDimensions();
                Console.WriteLine("Bot initializing... happy botting!");
                Rectangle resizeTo = new Rectangle(10, 10, 1280, 720);
                window.ResizeWindowDimensions(resizeTo);


                //start script looping here
                while (true)
                {
                    Bitmap screenshot = window.GetMostRecentScreenshot();

                    // logic for selecting current script // await user input for selected script

                    //if combat script selected look to do this on steady interval
                    player.CombatCheck(screenshot);
                    if (!player.IsInCombat)
                    {
                        closeProxEnemies = player.ScanForCloseProxEnemies(screenshot, chicken.MainColor, tolerance);
                        foreach (Vector2 point in closeProxEnemies)
                        {
                            Console.WriteLine(point);
                        }
                        for (int i = 0; i < closeProxEnemies.Count; i++)
                        {
                            try
                            {
                                Vector2 toClick = new Vector2(closeProxEnemies[i].X + 50,
                                                              closeProxEnemies[i].Y + 50);

                                player.AttackPotentialEnemy(toClick);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine($"error targeting close prox enenemy {i}");
                            }
                        }
                    }

                    System.Threading.Thread.Sleep(5000);
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
}

