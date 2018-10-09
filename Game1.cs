using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PrototypeGame2
{
    public class Game1 : Game
    {
        private enum eProcess { UPDATE, DRAW }
        private eProcess process;
        private GameManager gm;
        public int WIDTH = 200;
        public int HEIGHT = 200;

        public const float UPDATE_CAP = 1.0f / 60f;
        private float firstTime = 0f;
        private float lastTime = 0f;
        private float passedTime = 0f;
        private float unprocessedTime = 0f;
        private float frameTime = 0f;
        private int frames = 0;
        private int fps = 0;
        private bool render = false;

        GameTime gt;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            gt = new GameTime();

            firstTime = 0;
            lastTime = (float)gt.TotalGameTime.TotalSeconds;
            passedTime = 0;
            unprocessedTime = 0;

            frameTime = 0;
            frames = 0;
            fps = 0;

            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.ApplyChanges();
            gm = new GameManager(this);
            //Window.Position = new Point(2500, 0);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            gm.Load(this);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gt = gameTime;
            firstTime = (float)gt.TotalGameTime.TotalSeconds;
            passedTime = firstTime - lastTime;
            lastTime = firstTime;

            unprocessedTime += passedTime;
            frameTime += passedTime;

            render = false;

            while(unprocessedTime >= UPDATE_CAP)
            {
                unprocessedTime -= UPDATE_CAP;
                render = true;

                //TODO: UPDATE GAME
                gm.Update(UPDATE_CAP, fps);

                base.Update(gt);

                if(frameTime >= 1.0)
                {
                    frameTime = 0;
                    fps = frames;
                    frames = 0;
                }

                frames++;
            }

            if(render)
            {
                process = eProcess.DRAW;
            }
            else
            {
                process = eProcess.UPDATE;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            gt = gameTime;
            if (process.Equals(eProcess.DRAW))
            {

                GraphicsDevice.Clear(Color.CornflowerBlue);

                //TODO DRAW
                //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, null, null, null);
                gm.Draw(spriteBatch, UPDATE_CAP);
                //spriteBatch.End();

                base.Draw(gt);
            }
        }

        public int getWidth() { return WIDTH; }
        public int getHeight() { return HEIGHT; }
    }
}
