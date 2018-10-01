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

        private int frame = 1; //default to frame 1

        private float x = 0, y = 0; //default x and y to zero

        private float scale;

        public SpriteSheet(Game1 game1, float scale)
        {
            this.game1 = game1;
            this.scale = scale;
        }
        
        public void Load(string path)
        {
            spriteSheet = game1.Content.Load<Texture2D>(path);
            spriteSheetWidth = spriteSheet.Width;
            spriteSheetHeight = spriteSheet.Height;

        }

        public void Update(float UC)
        {

        }

        public void Draw(SpriteBatch sp, float UC)
        {
            sp.Draw(spriteSheet, Destination(x, y), SpriteView(frame, 1), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public Vector2 Destination(float x, float y)
        {
           
            return new Vector2(x, y);
        }

        public Rectangle SpriteView(int frame, int layer)
        {
            int totalNumberOfFrames = getFrames();
            int totalNumberOfLayers = 1;

            int spriteFrameWidth = spriteWidth = spriteSheetWidth / totalNumberOfFrames;
            int spriteFrameHeight = spriteHeight = spriteSheetHeight / totalNumberOfLayers;

            int spriteFrameX = (spriteSheetWidth / totalNumberOfFrames) * (frame - 1);
            int spriteFrameY = (spriteSheetHeight / totalNumberOfLayers) * (layer - 1);

            return new Rectangle(spriteFrameX, spriteFrameY, spriteFrameWidth, spriteFrameHeight);
        }

        public int getFrames()
        {
            int count = 0;
            Color[] colorData = new Color[spriteSheetWidth * spriteSheetHeight];

            spriteSheet.GetData<Color>(colorData);

            for(int w = 0; w < spriteSheetWidth; w++)
            {
                if (colorData[w].Equals(black()))
                {
                    if (!colorData[w + 1].Equals(black()) && (w + 1) < spriteSheetWidth)
                    {
                        count++;
                    }
                }
            }
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
        public int getCurrentFrame() { return frame; }
        public float getScale() { return scale; }
        public float getX() { return x; }
        public float getY() { return y; }
        public void setX(float x) { this.x = x; }
        public void setY(float y) { this.y = y; }
        public void setScale(float scale) { this.scale = scale; }
        public void setCurrentFrame(int frame) { this.frame = frame; }
    }
}
