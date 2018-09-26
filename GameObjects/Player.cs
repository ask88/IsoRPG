using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using PrototypeGame2.ENUMS;

namespace PrototypeGame2.GameObjects
{
    public class Player : GameObject
    {
        private GameManager gm;
        private float speed = 100;
        private float offX, offY, posX, posY;
        private int tileX, tileY;

        public Player(GameManager gm, eTag tag, string path, float posX, float posY) :
            base(tag, path, posX, posY)
        {
            this.gm = gm;
            posX = posX * gm.TILE_SIZE;
            posY = posY * gm.TILE_SIZE;
        }

        public override void Load(Game1 g)
        {
            base.Load(g);
        }

        public override void Update(float dt)
        {
            KeyboardState ks = Keyboard.GetState();

            if(ks.IsKeyDown(Keys.W))
            {
                offY -= dt * speed;
            }

            if (ks.IsKeyDown(Keys.S))
            {
                offY += dt * speed;
            }

            if (ks.IsKeyDown(Keys.A))
            {
                offX -= dt * speed;
            }

            if (ks.IsKeyDown(Keys.D))
            {
                offX += dt * speed;
            }


            if (offY > gm.TILE_SIZE / 2)
            {
                tileY++;
                offY -= gm.TILE_SIZE;
            }

            if (offY < gm.TILE_SIZE / 2)
            {
                tileY--;
                offY += gm.TILE_SIZE;
            }

            if (offX > gm.TILE_SIZE / 2)
            {
                tileX++;
                offX -= gm.TILE_SIZE;
            }

            if(offX < gm.TILE_SIZE / 2)
            {
                tileX--;
                offX += gm.TILE_SIZE;
            }

            posX = tileX * gm.TILE_SIZE + offX;
            posY = tileY * gm.TILE_SIZE + offY;

            base.Update(dt);
        }

        public override void Draw(SpriteBatch sp, float dt)
        {
            sp.Draw(texture, new Vector2(posX, posY), null, Color.White, 0f, Vector2.Zero,  1f, SpriteEffects.None, 0f);
            base.Draw(sp, dt);
        }
    }
}
