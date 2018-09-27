using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrototypeGame2.GFX
{
    public class SpriteSheet
    {
        Game1 game1;
        Texture2D spriteSheet;

        private int spriteSheetWidth;
        private int spriteSheetHeight;
        private int spriteWidth;
        private int spriteHeight;

        public SpriteSheet(Game1 game1)
        {
            this.game1 = game1;
        }
        
        public void Load(string path)
        {
            spriteSheet = game1.Content.Load<Texture2D>(path);
            spriteSheetWidth = spriteSheet.Width;
            spriteSheetHeight = spriteSheet.Height;
            //System.Console.WriteLine(spriteSheetWidth * spriteSheetHeight);
            System.Console.WriteLine(getFrames());
        }

        public Rectangle SpriteView(int frame, int layer)
        {
            int totalNumberOfFrames = 3;
            int totalNumberOfLayers = 1;

            int spriteFrameWidth = spriteWidth = spriteSheetWidth / totalNumberOfFrames;
            int spriteFrameHeight = spriteHeight = spriteSheetHeight / totalNumberOfLayers;

            int spriteFrameX = (spriteSheetWidth / totalNumberOfFrames) * (frame - 1);
            int spriteFrameY = (spriteSheetHeight / totalNumberOfLayers) * (layer - 1);

            return new Rectangle(spriteFrameX, spriteFrameY, spriteFrameWidth, spriteFrameHeight);
        }

        public int getFrames()
        {
            //get color data from texture
            //loop through color data looking for color
            //increment when color is found
            int count = 0;
            string topLayer = "";
            Color[] colorData = new Color[spriteSheetWidth * spriteSheetHeight];

            spriteSheet.GetData<Color>(colorData);

            for(int w = 0; w < spriteSheetWidth; w++)
            {
                if (colorData[w].Equals(black()))
                {
                    topLayer = topLayer + "B ";
                    if (!colorData[w + 1].Equals(black()) && (w + 1) < spriteSheetWidth)
                    {
                        count++;
                    }
                }
                else if (colorData[w].Equals(white()))
                {
                    topLayer = topLayer + "W ";
                }
                else
                {
                    topLayer = topLayer + "X ";
                }
            }

            System.Console.WriteLine(topLayer);
            return count;
        }

        public Color black()
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            int alpha = 255;

            return new Color(red, green, blue, alpha);
        }

        public Color white()
        {
            int red = 255;
            int green = 255;
            int blue = 255;
            int alpha = 255;

            return new Color(red, green, blue, alpha);
        }

        public int getSpriteSheetWidth() { return spriteSheetWidth; }
        public int getSpriteSheetHeight() { return spriteSheetHeight; }
        public int getSpriteWidth() { return spriteWidth; }
        public int getSpriteHeight() { return spriteHeight; }
    }
}
