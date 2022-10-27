using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using IronOcr;


namespace OSRSBadBot
{
    internal class ImageDetectionManager
    {
        private Bitmap? _currentBitmap;
        private Bitmap? _lastBitmap;
        private Bitmap? _savedBitmap;
        public ImageDetectionManager()
        {
            _currentBitmap = null;
            _lastBitmap = null;
            _savedBitmap = null;
        }

        // --- refactored for Bmp parameter only --- //

        //public void ScanBitmapForText(Bitmap bmp, Rectangle contentArea)
        //{
        //    _currentBitmap = bmp;
        //    var OCR = new IronTesseract();

        //    using (var Input = new OcrInput())
        //    {
        //        Input.Add(bmp);
        //        var Result = OCR.Read(Input);
        //        Console.WriteLine(Result.ToString());
        //    }
        //}

        //public void ScanBitmapForText(String path)
        //{
        //    var OCR = new IronTesseract();

        //    using (var Input = new OcrInput())
        //    {
        //        Input.Add(path);
        //        var Result = OCR.Read(Input);
        //        Console.WriteLine(Result.Text);
        //    }
        //}

        //checks if any text is present in the bitmap
        public bool ScanBitmapForText(Bitmap bmp)
        {
            var OCR = new IronTesseract();

            using (var Input = new OcrInput())
            {
                Input.Add(bmp);
                var Result = OCR.Read(Input);
                Console.WriteLine($"Character Recognition Found {Result.Text}");
                if(Result.Text.Length >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //creates list of points containing pixels within tolerance of an object with unique color properties
        public List<Vector2> ScanBitmapForMatchingColorPixelsList(Bitmap screenshot, Color color, int tolerance)
        {
            List<Vector2> result = new List<Vector2>();
            int toleranceSquared = tolerance * tolerance;
            int x;
            int y;
            for (x = 0; x < screenshot.Width; x++)
            {
                for (y = 0; y < screenshot.Height; y++)
                {
                    Color pixel = screenshot.GetPixel(x, y);
                    if(pixel == color)
                    {
                        result.Add(new Vector2(x, y));
                    }
                }
            }

            return result;
        }

        private string GetTextResult(string text)
        {
            return text;
        }


        public bool ScanBitmapForItem(Bitmap item, Bitmap bmp)
        {
            _currentBitmap = bmp;
            throw new NotImplementedException();
        }

        public bool CompareBitmapToLast(Bitmap bmp)
        {
            _currentBitmap = bmp;
            throw new NotImplementedException();
        }
    }
}
