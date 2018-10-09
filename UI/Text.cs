using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace PrototypeGame2.UI
{
	public class Text
	{
		public struct fontDetails
		{
			public int x;
			public int y;
			public int frameWidth;
		}

		private Game1 game1;
		private Texture2D font;
		private Vector2 pos;
		private fontDetails[] fd;

		private float scale;
		private string message;
		public Text(Game1 game1, float scale)
		{
			this.game1 = game1;
			this.scale = scale;
		}

		//an array that holds all the characters that the text engine will use.
		private char[] alpha = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
			'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '.', ',', '?'};

		//loading in the asset that the engine will pull from
		public void Load(string fileName)
		{
			font = game1.Content.Load<Texture2D>(fileName);
		}

		//the heart of the engine
		//messageinput takes in a string, what needs to be drawn to screen
		public fontDetails[] MessageInput(string message)
		{
			//assigns the value to another message variable to be used in class
			this.message = message;

			//instantiate a new struct with the length of the message
			fd = new fontDetails[message.Length];
			//loop through and make an empty array that will hold struct data
			for (int i = 0; i < message.Length; i++)
			{
				fd[i] = new fontDetails();
			}

			//loop through and get the data that will be sent to the draw method for each individual character
			for (int i = 0; i < message.Length; i++)
			{
				for (int j = 0; j < alpha.Length; j++)
				{
					if (message[i].Equals(alpha[j]))
					{
						//calling getFrameX method
						fd[i].x = getFrameX(j);
						//set the y to be at 1, instead of 0, so that the drawing method will not draw the start/end colors
						fd[i].y = 1;
						//set the framewidth of each individual character
						fd[i].frameWidth = getFrameWidth(j);
					}
				}
			}
			return fd;
		}

		private int getFrameX(int index)
		{
			//get color information from the texture that was loaded
			Color[] textureColor = new Color[font.Width * font.Height];
			int[] alphaPosition = new int[alpha.Length];

			int count = 0;
			font.GetData<Color>(textureColor);

			for (int x = 0; x<font.Width; x++)
			{
				//look for the used yellow, and used blue colors in the texture that indicates start/end of each frame
				if ((textureColor[x].Equals(yellowColor())) ||
					 (textureColor[x].Equals(blueColor())))
				{
					//look for the yellow color that indicates the start of the frame
					if (textureColor[x].Equals(yellowColor()))
					{
						//store that starting int into the position array
						alphaPosition[count++] = x + 1;
					}
				}
			}
			//return the int from the called index position of the array
			return alphaPosition[index];
		}

		private int getFrameWidth(int index)
		{
			//get color information from the texture again
			Color[] textureColor = new Color[font.Width * font.Height];
			int[] frameWidth = new int[alpha.Length];

			int pixelWidth = 0;
			int count = 0;

			font.GetData<Color>(textureColor);

			for (int x = 0; x<font.Width; x++)
			{
				//look for the yellow and blue color
				if ((textureColor[x].Equals(yellowColor())) ||
					 (textureColor[x].Equals(blueColor())))
				{

					if (pixelWidth != 0)
					{
						//after the start/end colors, the accumulator starts counting the get the width of the frame
						frameWidth[count++] = pixelWidth;
					}

					pixelWidth = 0;

				}
				else
				{
					pixelWidth++;
				}
			}
			//it returns the int of the width, called from the index of the array
			return frameWidth[index];
		}

		//the draw method
		public void Draw(SpriteBatch spriteBatch)
		{
			//made an array that will hold the location of each letter that follows the starting letter of the drawn word
			float[] wordSpacing = new float[message.Length];

			//loops through and sets each elements with a number that represents an x coordinate to be drawn to screen
			for (int i = 0; i < message.Length; i++)
			{
				if (i != 0)
				{
					//the wordspacing is set to the location of the last word, plus the width of the last word, plus a buffer pixel
					//that is all multiplied by the scale, so that the text can be different sizes based off the set scale in the constructor
					wordSpacing[i] = wordSpacing[i - 1] + 1 + (fd[i - 1].frameWidth * scale);
				}
				else
				{
					//this is the beginning letter of the drawn word
					wordSpacing[i] = pos.X;
				}

			}

			spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);
			for (int i = 0; i < message.Length; i++)
			{
				//the spritebatch draws, and sets the position based off the wordSpacing element.  It then draws all letters in their locations
				spriteBatch.Draw(font, new Vector2(wordSpacing[i], pos.Y), new Rectangle(fd[i].x, fd[i].y, (fd[i].frameWidth), (5)), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);   
			}
			spriteBatch.End();
		}

		//setters to set location of the canvas to draw the entire word.
        public float getPosition_X() { return pos.X; }
        public float getPosition_Y() { return pos.Y; }
		public void setPosition_X(float x) { pos.X = x; }
		public void setPosition_Y(float y) { pos.Y = y; }

        private Color yellowColor()
        {
            return new Color(251, 242, 54, 255);
        }

        private Color blueColor()
        {
            return new Color(68, 58, 241, 255);
        }
	}
}
