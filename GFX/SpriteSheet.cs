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


        public int getSpriteSheetWidth() { return spriteSheetWidth; }
        public int getSpriteSheetHeight() { return spriteSheetHeight; }
        public int getSpriteWidth() { return spriteWidth; }
        public int getSpriteHeight() { return spriteHeight; }
    }
}
