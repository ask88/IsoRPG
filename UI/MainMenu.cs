using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrototypeGame2.INPUT;

namespace PrototypeGame2.UI
{
    public class MainMenu
    {
        private GameManager game;
        private int x = 0;
        private int y = 0;
        private Rectangle selectionBox;
        private KeyboardInput keyboardInput;
        private GamepadInput gamepadInput;

        private bool trigger = false;

    public MainMenu(GameManager game, KeyboardInput keyboardInput, GamepadInput gamepadInput)
        {
            this.game = game;
            selectionBox = new Rectangle(x, y, 60, 40);
            this.keyboardInput = keyboardInput;
            this.gamepadInput = gamepadInput;
        }

        public void Load()
        {

        }

        public void Update(float UC)
        {
            //need to edit keyboard input class because the oldstate is being set and preventing other keys from being pressed.
            //the method executes to try and evaluate the condition and sets the oldstate which will equate false for other keys

            if (keyboardInput.actionBtn())
            {
                System.Console.WriteLine("UP");
                selectionBox.Y = selectionBox.Y + 40;
            }

        }

        public void Draw(SpriteBatch sp, float UC)
        {
            sp.Draw(game.drawHorizontalLine(selectionBox.Width), new Vector2(selectionBox.X, selectionBox.Y), null, Color.Black, 0f, Vector2.Zero, game.SCALE, SpriteEffects.None, 0f);
            sp.Draw(game.drawHorizontalLine(selectionBox.Width), new Vector2(selectionBox.X, selectionBox.Y + selectionBox.Height), null, Color.Black, 0f, Vector2.Zero, game.SCALE, SpriteEffects.None, 0f);
            sp.Draw(game.drawVerticalLine(selectionBox.Height), new Vector2(selectionBox.X, selectionBox.Y), null, Color.Black, 0f, Vector2.Zero, game.SCALE, SpriteEffects.None, 0f);
            sp.Draw(game.drawVerticalLine(selectionBox.Height), new Vector2(selectionBox.X + selectionBox.Width, selectionBox.Y), null, Color.Black, 0f, Vector2.Zero, game.SCALE, SpriteEffects.None, 0f);
        }
    }
}
