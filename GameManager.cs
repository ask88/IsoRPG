using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PrototypeGame2.ENUMS;
using PrototypeGame2.GameObjects;
using PrototypeGame2.GFX;
using System.Collections.Generic;

namespace PrototypeGame2
{
    public class GameManager
    {
        private eLevelTag lTag = eLevelTag.LEVEL;
        private List<GameObject> objects = new List<GameObject>();
        private List<LevelObject> levelObjects = new List<LevelObject>();
        private Game1 game;

        public float SCALE = 1;
        public int TILE_SIZE = 8;
        public int screenWidth, screenHeight;

        private KeyboardState state;
        private KeyboardState oldState;

        private SpriteSheet testSpriteSheet;

        public GameManager(Game1 game)
        {
            this.game = game;
            screenWidth = game.WIDTH / TILE_SIZE;
            screenHeight = game.HEIGHT / TILE_SIZE;

            testSpriteSheet = new SpriteSheet(game, 4f);

        }

        public void Load(Game1 g)
        {
            testSpriteSheet.Load("testSpriteSheet");

            for(int i = 0; i < levelObjects.Count; i++)
            {
                //levelObjects[i].Load(g);
            }

            for(int i = 0; i < objects.Count; i++)
            {
                //objects[i].Load(g);
            }
        }

        public void Update(float dt)
        {
            state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
            {
                testSpriteSheet.setCurrentFrame(2);
            }
            if(state.IsKeyUp(Keys.Space) && oldState.IsKeyUp(Keys.Down))
            {
                testSpriteSheet.setCurrentFrame(1);
            }

            testSpriteSheet.Update(dt);

            oldState = Keyboard.GetState();

            for (int i = 0; i < levelObjects.Count; i++)
            {
                if(levelObjects[i].getTag().Equals(lTag))
                {
                    levelObjects[i].Update(dt);
                }
            }

            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(dt);
            }
        }

        public void Draw(SpriteBatch sp, float dt)
        {
            //sp.Draw(drawVerticalLine(), new Vector2(game.WIDTH / 2, 0), null);
            //sp.Draw(drawHorizontalLine(), new Vector2(0, game.HEIGHT / 2), null);

            testSpriteSheet.Draw(sp, dt);

            for (int i = 0; i < levelObjects.Count; i++)
            {
                if (levelObjects[i].getTag().Equals(lTag))
                {
                    levelObjects[i].Draw(sp, dt);
                }
            }

            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(sp, dt);
            }
        }

        public void addGameObject(GameObject go)
        {
            objects.Add(go);
        }

        public void addLevelObject(LevelObject lo)
        {
            levelObjects.Add(lo);
        }

        public GameObject getObjectByID(eTag tag)
        {
            for(int i = 0; i < objects.Count; i++)
            {
                if(objects[i].getTag().Equals(tag))
                {
                    return objects[i];
                }
            }

            return null;
        }

        public LevelObject getLevelByID(eTag tag)
        {
            for (int i = 0; i < levelObjects.Count; i++)
            {
                if (levelObjects[i].getTag().Equals(tag))
                {
                    return levelObjects[i];
                }
            }

            return null;
        }

        public Texture2D drawVerticalLine()
        {
            Color[] verticalLine = new Color[game.HEIGHT];
            for(int i = 0; i < verticalLine.Length; i++)
            {
                verticalLine[i] = Color.Black;
            }
            Texture2D vTexture = new Texture2D(game.GraphicsDevice, 1, game.HEIGHT);
            vTexture.SetData<Color>(verticalLine);
            return vTexture;
        }

        public Texture2D drawHorizontalLine()
        {
            Color[] horizontalLine = new Color[game.WIDTH];
            for (int i = 0; i < horizontalLine.Length; i++)
            {
                horizontalLine[i] = Color.Black;
            }
            Texture2D vTexture = new Texture2D(game.GraphicsDevice, game.WIDTH, 1);
            vTexture.SetData<Color>(horizontalLine);
            return vTexture;
        }
    }
}
