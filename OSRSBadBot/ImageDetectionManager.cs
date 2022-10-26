using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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
