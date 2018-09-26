using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrototypeGame2.ENUMS;

namespace PrototypeGame2
{
    public abstract class GameObject
    {
        private float x, y;
        private int width, height;
        protected Texture2D texture;
        private string path;
        private eTag tag;

        public GameObject(eTag tag, string path, float posX, float posY)
        {
            this.tag = tag;
            this.path = path;
            x = posX;
            y = posY;
        }

        public virtual void Load(Game1 g)
        {
            texture = g.Content.Load<Texture2D>(path);
            width = texture.Width;
            height = texture.Height;
        }

        public virtual void Update(float dt)
        {

        }

        public virtual void Draw(SpriteBatch sp, float dt)
        {

        }

        public Rectangle Bounds()
        {
            return new Rectangle((int)x, (int)y, width, height);
        }

        public float getX() { return x; }
        public float getY() { return y; }
        public void setX(int x) { this.x = x; }
        public void setY(int y) { this.y = y; }

        public int getWidth() { return width; }
        public int getHeight() { return height; }

        public void setTag(eTag tag) { this.tag = tag; }
        public eTag getTag() { return tag; }
    }
}
