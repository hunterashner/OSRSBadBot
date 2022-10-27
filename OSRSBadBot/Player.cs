using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace OSRSBadBot
{
    internal class Player
    {
        public string saveImagePath;
        private string saveMouseHoverImagePath;
        private string saveCloseProxEnemiesPath;
        public ImageDetectionManager imageDetectionManager;
        public bool IsInCombat { get; set; }
        public bool IsHoveringClickableAction { get; set; }
        public Rectangle CombatXPIndicatorRect { get; private set; }
        public Rectangle MainGameRect { get; private set; }
        public Rectangle MouseHoverTextArea { get; private set; }

        public Player()
        {
            saveImagePath = "c:\\Users\\hunter\\Pictures\\screenshot.bmp";
            saveMouseHoverImagePath = "c:\\Users\\hunter\\Pictures\\mousehover.bmp";
            saveCloseProxEnemiesPath = "c:\\Users\\hunter\\Pictures\\closeProxEnemies.bmp";

            //houses all IronOCR functionality
            imageDetectionManager = new ImageDetectionManager();

            //rectangle region where current combat xp is displayed on window
            CombatXPIndicatorRect = new Rectangle(1005, 35, 50, 25);

            //rectangle region of main game minus all GUI
            MainGameRect = new Rectangle(50, 50, 1000, 500);

            //rectangle region of main game, top left corner of game screen, displays action taken if left click
            MouseHoverTextArea = new Rectangle(10, 35, 250, 15);

            IsInCombat = false;
            IsHoveringClickableAction = false;
        }

        public void CombatCheck(Bitmap screenshot)
        {
            Bitmap resized = screenshot.Clone(CombatXPIndicatorRect, screenshot.PixelFormat);
            resized.Save(saveImagePath);
            if (imageDetectionManager.ScanBitmapForText(resized))
            {
                IsInCombat = true;
                Console.WriteLine("player is in combat.");
            }
            else
            {
                IsInCombat = false;
                Console.WriteLine("player not in combat");
            }
        }

        public void CheckMouseHoverAction(Bitmap screenshot, Enemy? target)
        {
            Bitmap mouseHoverTextArea = screenshot.Clone(MouseHoverTextArea, screenshot.PixelFormat);
            Console.WriteLine("saving text area of current hovered object");
            try
            {
                mouseHoverTextArea.Save(saveMouseHoverImagePath);
                Console.WriteLine("save completed");
                if (imageDetectionManager.ScanBitmapForText(mouseHoverTextArea))
                {
                    IsHoveringClickableAction = true;
                }
                else
                {
                    IsHoveringClickableAction = false;
                }
            }
            catch
            {
                Console.WriteLine("save of text area failed");
            }
        }

        //color is = target enemies unique color property
        public List<Vector2> ScanForCloseProxEnemies(Bitmap screenshot, Color color, int tolerance)
        {
            List<Vector2> potentialEnemies;
            Bitmap gameWindow = screenshot.Clone(MainGameRect, screenshot.PixelFormat);
            gameWindow.Save(saveCloseProxEnemiesPath);
            Console.WriteLine($"Scanning window for enemies with definable color {color}");
            potentialEnemies = imageDetectionManager.ScanBitmapForMatchingColorPixelsList(gameWindow, color, tolerance);
            return potentialEnemies;
        }

        public void AttackPotentialEnemy(Vector2 coords)
        {
            try
            {
                WindowHelpers.SendCursorToPosition(coords);
                WindowHelpers.SendLeftclickDown();
                WindowHelpers.SendLeftclickUp();
                Console.WriteLine($"Left click input at position {coords.ToString()}");
            }
            catch
            {
                Console.WriteLine("error attempting to click enemey coordinates");
            }
        }

        public void ContinueInCurrentCombat()
        {

        }
    }
}
