using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OSRSBadBot
{
    internal class Player
    {
        public string saveImagePath;
        private string saveMouseHoverImagePath;
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

            //houses all IronOCR functionality
            imageDetectionManager = new ImageDetectionManager();

            //rectangle region where current combat xp is displayed on window
            CombatXPIndicatorRect = new Rectangle(720, 40, 780 - 730, 60 - 40);

            //rectangle region of main game minus all GUI
            MainGameRect = new Rectangle(275, 35, 770 - 275, 330);

            //rectangle region of main game, top left corner of game screen, displays action taken if left click
            MouseHoverTextArea = new Rectangle(255, 35, 120, 20);

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

        public void AttackTargetEnemy(Bitmap screenshot, Enemy? target)
        {
            Bitmap gameWindow = screenshot.Clone(MainGameRect, screenshot.PixelFormat);
            Bitmap mouseHoverTextArea = screenshot.Clone(MouseHoverTextArea, screenshot.PixelFormat);
            Console.WriteLine("saving text area of current hovered object");
            try
            {
                mouseHoverTextArea.Save(saveMouseHoverImagePath);
                Console.WriteLine("save completed");
            }
            catch
            {
                Console.WriteLine("save of text area failed");
            }

            if (imageDetectionManager.ScanBitmapForText(mouseHoverTextArea))
            {
                IsHoveringClickableAction = true;
            } 
            else
            {
                IsHoveringClickableAction = false;
            }

            //int x;
            //int y;
            //for(int i = 0; i < MainGameRect.Width * MainGameRect.Height; i++)
            //{
            //    //if (gameWindow.GetPixel())
            //    //{

            //    //}     
            //}
        }

        public void ContinueInCurrentCombat()
        {

        }
    }
}
