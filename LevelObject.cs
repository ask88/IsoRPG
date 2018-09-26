using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrototypeGame2.ENUMS;

namespace PrototypeGame2
{
    public class LevelObject
    {
        private int startX, endX, startY, endY, width, height;
        private string path;
        private eLevelTag tag;
        private Texture2D texture;
        private GameObject player;

        public LevelObject(eLevelTag tag, string path, int startX, int startY,
            int endX, int endY, int width, int height, GameObject player)
        {
            this.tag = tag;
            this.path = path;
            this.startX = startX;
            this.startY = startY;
            this.endX = endX;
            this.endY = endY;
            this.width = width;
            this.height = height;
            this.player = player;
        }

        public void Load(Game1 g)
        {
            texture = g.Content.Load<Texture2D>(path);
            mapCollision();
        }

        public void Update(float dt)
        {
            if(inStartArea(player))
            {

            }

            if(inEndArea(player))
            {

            }
        }

        public void Draw(SpriteBatch sp, float dt)
        {

        }

        private void mapCollision()
        {
            Color[] pixelArray = new Color[width * height];
            texture.GetData<Color>(pixelArray);


        }

        private bool inStartArea(GameObject go)
        {
            if(((go.getX() > startX) && ((go.getX() + go.getWidth()) < (startX + width))) &&
                (go.getY() > startY) && ((go.getY() + go.getHeight()) < (startY + height)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool inEndArea(GameObject go)
        {
            if (((go.getX() > endX) && ((go.getX() + go.getWidth()) < (endX + width))) &&
                (go.getY() > endY) && ((go.getY() + go.getHeight()) < (endY + height)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setTag(eLevelTag tag) { this.tag = tag; }
        public eLevelTag getTag() { return tag; }

        public int getStartX() { return startX; }
        public int getStartY() { return startY; }
        public void setStartX(int startX) { this.startX = startX; }
        public void setStartY(int startY) { this.startY = startY; }

        public int getEndX() { return endX; }
        public int getEndY() { return endY; }
        public void setEndX(int endX) { this.endX = endX; }
        public void setEndY(int endY) { this.endY = endY; }

        public int getWidth() { return width; }
        public int getHeight() { return height; }
    }
}
