using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrototypeGame2.GFX;
using PrototypeGame2.INPUT;

namespace PrototypeGame2.UI
{
    public class MainMenu
    {
        private GameManager game;
        private int x = 0;
        private int y = 0;
        private float textX = 0;
        private float textY = 0;

        private Rectangle selectionBox;
        private KeyboardInput keyboardInput;
        private GamepadInput gamepadInput;

        private Text text;

    public MainMenu(GameManager game, KeyboardInput keyboardInput, GamepadInput gamepadInput)
        {
            this.game = game;
            selectionBox = new Rectangle(x, y, 60, 40);
            this.keyboardInput = keyboardInput;
            this.gamepadInput = gamepadInput;
            text = new Text(game.getGame1(), game.SCALE*2);
        }

        public void Load()
        {
            text.Load("font/alpha");
            text.MessageInput("chi");
            text.setPosition_X(0);
            text.setPosition_Y(0);
            textX = text.getPosition_X();
            textY = text.getPosition_Y();
        }

        public void Update(GameTime gt)
        {
            //need to edit keyboard input class because the oldstate is being set and preventing other keys from being pressed.
            //the method executes to try and evaluate the condition and sets the oldstate which will equate false for other keys

            if (keyboardInput.upBtn())
            {
                selectionBox.Y = selectionBox.Y - 40;
                text.setPosition_Y(textY - 40);
                textY = text.getPosition_Y();
            }

            if (keyboardInput.downBtn())
            {
                selectionBox.Y = selectionBox.Y + 40;
                text.setPosition_Y(textY + 40);
                textY = text.getPosition_Y();
            }

            if(keyboardInput.rightBtn())
            {
                selectionBox.X = selectionBox.X + 40;
                text.setPosition_X(textX + 40);
                textX = text.getPosition_X();
            }

            if(keyboardInput.leftBtn())
            {
                selectionBox.X = selectionBox.X - 40;
                text.setPosition_X(textX - 40);
                textX = text.getPosition_X();
            }
        }

        public void Draw(SpriteBatch sp)
        {
            text.Draw(sp);

            sp.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, null, null, null);
            sp.Draw(game.drawHorizontalLine(selectionBox.Width), new Vector2(selectionBox.X, selectionBox.Y), null, Color.Black, 0f, Vector2.Zero, game.SCALE, SpriteEffects.None, 0f);
            sp.Draw(game.drawHorizontalLine(selectionBox.Width), new Vector2(selectionBox.X, selectionBox.Y + selectionBox.Height), null, Color.Black, 0f, Vector2.Zero, game.SCALE, SpriteEffects.None, 0f);
            sp.Draw(game.drawVerticalLine(selectionBox.Height), new Vector2(selectionBox.X, selectionBox.Y), null, Color.Black, 0f, Vector2.Zero, game.SCALE, SpriteEffects.None, 0f);
            sp.Draw(game.drawVerticalLine(selectionBox.Height), new Vector2(selectionBox.X + selectionBox.Width, selectionBox.Y), null, Color.Black, 0f, Vector2.Zero, game.SCALE, SpriteEffects.None, 0f);
            sp.End();
        }
    }
}
