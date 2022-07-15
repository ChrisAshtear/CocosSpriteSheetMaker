using System;

namespace CocosSpriteSheetMaker // Note: actual namespace depends on the project name.
{
    public class Vector2
    {
        public int x, y;
    }
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*if(args.Length == 0)
            {
                Console.WriteLine("Need widthxheight of image, sprite wxh. sheetmaker.exe 512x2048 128");
            }*/
            string[] imgSize = new[] { "512", "2048" };
            //string imgSize = args[0];
            string[] sprSize = new[] { "128", "128" };
            //string sprSize = args[1];
            //split
            Vector2 imgSz = new Vector2{ x = int.Parse(imgSize[0]), y= int.Parse(imgSize[1]) };
            Vector2 sprSz = new Vector2{ x = int.Parse(sprSize[0]), y= int.Parse(sprSize[1]) };
            SheetMaker.getFiles();
            //SheetMaker.CreateSheet(imgSz, sprSz);
        }
    }
}