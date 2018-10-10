using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrototypeGame2.INPUT;
using PrototypeGame2.UI;

namespace PrototypeGame2
{
    public enum GameState { main_menu, new_game, load_menu, options_menu};

    public class GameManager
    {
        private Game1 game;

        public float SCALE = 1;
        public int TILE_SIZE = 8;
        public int screenWidth, screenHeight;

        private GameState state;

        private KeyboardInput keyboardInput;
        private GamepadInput gamepadInput;

        private MainMenu mainMenu;

        public GameManager(Game1 game)
        {
            this.game = game;
            screenWidth = game.WIDTH / TILE_SIZE;
            screenHeight = game.HEIGHT / TILE_SIZE;

            state = GameState.main_menu;
            keyboardInput = new KeyboardInput();
            gamepadInput = new GamepadInput();

            //Game States
            mainMenu = new MainMenu(this, keyboardInput, gamepadInput);
        }

        public void Load(Game1 g)
        {
            mainMenu.Load();
        }

        public void Update(GameTime gt)
        {
            switch(state)
            {
                case GameState.main_menu:
                    mainMenu.Update(gt);
                    break;
                case GameState.load_menu:
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch sp)
        {
            switch(state)
            {
                case GameState.main_menu:
                    mainMenu.Draw(sp);
                    break;
                case GameState.load_menu:
                    
                    break;
                default:
                    break;
            }
        }

        public Texture2D drawVerticalLine(int height)
        {
            Color[] verticalLine = new Color[height];
            for(int i = 0; i < verticalLine.Length; i++)
            {
                verticalLine[i] = Color.Black;
            }
            Texture2D vTexture = new Texture2D(game.GraphicsDevice, 1, height);
            vTexture.SetData<Color>(verticalLine);
            return vTexture;
        }

        public Texture2D drawHorizontalLine(int width)
        {
            Color[] horizontalLine = new Color[width];
            for (int i = 0; i < horizontalLine.Length; i++)
            {
                horizontalLine[i] = Color.Black;
            }
            Texture2D vTexture = new Texture2D(game.GraphicsDevice, width, 1);
            vTexture.SetData<Color>(horizontalLine);
            return vTexture;
        }

        public GameState getState() { return state; }
        public Game1 getGame1() { return game; }
        public void setState(GameState state) { this.state = state; }
    }
}
