using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocosSpriteSheetMaker
{
    public enum ResourceSize { small, med, large };
    public class SheetMaker
    {
        public static void getFiles()
        {

            Directory.SetCurrentDirectory("G:\\Projects\\Cocos\\2dChars\\assets\\sprites\\");
            string curpath = Directory.GetCurrentDirectory();
            string[] folders = Directory.GetDirectories(curpath);
            foreach(string folder in folders)
            {
                string sz = folder.Split("Units")[1];
                string[] sprSzStr = sz.Split('x');
                string[] images = Directory.GetFiles(folder, "*.png");
                Vector2 spriteSize = new Vector2 { x = int.Parse(sprSzStr[0]), y = int.Parse(sprSzStr[1]) };
                Vector2 imgSize = new Vector2 { x = int.Parse(sprSzStr[0])*4, y = int.Parse(sprSzStr[1])*16 };//temp
                foreach(string image in images)
                {
                    Console.WriteLine(image);
                    CreateSheet(imgSize, spriteSize, image);
                    //CreateSheet()
                }
            }    
        }


        public static void CreateSheet(Vector2 imgSz,Vector2 sprSz,string imgPath)
        {
            string fname = imgPath.Substring(imgPath.LastIndexOf('\\') + 1);
            string fsimpleName = imgPath.Split('.')[0];
            using StreamWriter file = new($"{fsimpleName}.plist");
            file.WriteLine($"<?xml version=\"1.0\" encoding=\"UTF - 8\"?>");
            file.WriteLine($"<plist version=\"1.0\">");
            file.WriteLine($"    <dict>");
            file.WriteLine($"        <key>frames</key>");
            file.WriteLine($"        <dict>");
            
            int numSprWide = imgSz.x / sprSz.x;
            int numSprHigh = imgSz.y / sprSz.y;
            int sprInImage = numSprWide * numSprHigh;
            int frameCtr = 0;
            for(int y = 0; y< numSprHigh; y++)
            {
                for(int x = 0; x < numSprWide; x++)
                {
                    file.WriteLine($"            <key>{frameCtr}</key>");
                    file.WriteLine($"            <dict>");
                    file.WriteLine($"                <key>aliases</key>");
                    file.WriteLine($"                <array/>");
                    file.WriteLine($"                <key>spriteOffset</key>");
                    file.WriteLine($"                <string>{{{0},{0}}}</string>");
                    file.WriteLine($"                <key>spriteSize</key>");
                    file.WriteLine($"                <string>{{{sprSz.x},{sprSz.y}}}</string>");
                    file.WriteLine($"                <key>spriteSourceSize</key>");
                    file.WriteLine($"                <string>{{{sprSz.x},{sprSz.y}}}</string>");
                    file.WriteLine($"                <key>textureRect</key>");
                    file.WriteLine($"                <string>{{{{{x*sprSz.x},{y*sprSz.y}}},{{{sprSz.x},{sprSz.y}}}}}</string>");
                    file.WriteLine($"                <key>textureRotated</key>");
                    file.WriteLine($"                <false/>");
                    file.WriteLine($"            </dict>");
                    frameCtr++;
                }
                
            }
            file.WriteLine($"        </dict>");
            file.WriteLine($"        <key>metadata</key>");
            file.WriteLine($"        <dict>");
            file.WriteLine($"            <key>format</key>");
            file.WriteLine($"            <integer>3</integer>");
            file.WriteLine($"            <key>pixelFormat</key>");
            file.WriteLine($"            <string>RGBA8888</string>");
            file.WriteLine($"            <key>premultiplyAlpha</key>");
            file.WriteLine($"            <false/>");
            file.WriteLine($"            <key>realTextureFileName</key>");
            file.WriteLine($"            <string>{fname}</string>");
            file.WriteLine($"            <key>size</key>");
            file.WriteLine($"            <string>{{{imgSz.x},{imgSz.y}}}</string>");
            file.WriteLine($"            <key>smartupdate</key>");
            file.WriteLine($"            <string>$TexturePacker:SmartUpdate:63fb717351e7f27d3acbeba0c97fe5b7:a8f840af5523c576fe1606e13421ab76:543da54f4cdf30f76a33554e42f69a3d$</string>");
            file.WriteLine($"            <key>textureFileName</key>");
            file.WriteLine($"            <string>{fname}</string>");
            file.WriteLine($"        </dict>");
            file.WriteLine($"    </dict>");
            file.WriteLine($"</plist>");

            file.Close();
        }
    }
}
