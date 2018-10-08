using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace PrototypeGame2.UI
{
    /*
     * 
     * supply GraphicsDevice.Viewport in the constructor
     * call the UpdateCamera() method in the Update loop and supply the GraphicsDevice.Viewport there aswell
     * 
     * 
     * this is the draw method
     * spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.Transform);
     */

    public class Camera
    {
        public float Zoom { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public Rectangle VisibleArea { get; protected set; }
        public Matrix Transform { get; protected set; }

        private float currentMouseWheelValue, previousMouseWheelValue, currentZoom, previousZoom;

        public Camera(Viewport viewport)
        {
            Bounds = viewport.Bounds;
            Zoom = 1f;
            Position = Vector2.Zero;
        }

        private void UpdateVisibleArea()
        {
            var inverseViewMatrix = Matrix.Invert(Transform);

            var topLeft = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var topRight = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
            var bottomLeft = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
            var bottomRight = Vector2.Transform(new Vector2(Bounds.Width, Bounds.Height), inverseViewMatrix);

            var min = new Vector2(
                MathHelper.Min(topLeft.X, MathHelper.Min(topRight.X, MathHelper.Min(bottomLeft.X, bottomRight.X))),
                MathHelper.Min(topLeft.Y, MathHelper.Min(topRight.Y, MathHelper.Min(bottomLeft.Y, bottomRight.Y))));
            var max = new Vector2(
                MathHelper.Max(topLeft.X, MathHelper.Max(topRight.X, MathHelper.Max(bottomLeft.X, bottomRight.X))),
                MathHelper.Max(topLeft.Y, MathHelper.Max(topRight.Y, MathHelper.Max(bottomLeft.Y, bottomRight.Y))));
            VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        private void UpdateMatrix()
        {
            Transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateScale(Zoom) *
                Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
            UpdateVisibleArea();
        }


        public void MoveCamera(Vector2 movePosition)
        {
            Vector2 newPosition = Position + movePosition;
            Position = newPosition;
        }

        public void AdjustZoom(float zoomAmount)
        {
            Zoom += zoomAmount;
            if( Zoom < .35f)
            {
                Zoom = .35f;
            }
            if(Zoom > 2f)
            {
                Zoom = 2f;
            }
        }

        public void UpdateCamera(Viewport bounds)
        {
            Bounds = bounds.Bounds;
            UpdateMatrix();

            Vector2 cameraMovement = Vector2.Zero;
            int moveSpeed;

            if(Zoom > .8f)
            {
                moveSpeed = 15;
            }
            else if(Zoom < .8f && Zoom >= .6f)
            {
                moveSpeed = 20;
            }
            else if(Zoom < .6f && Zoom > .35f)
            {
                moveSpeed = 25;
            }
            else if(Zoom <= .35f)
            {
                moveSpeed = 30;
            }
            else
            {
                moveSpeed = 10;
            }

            if(Keyboard.GetState().IsKeyDown(Keys.W/*KeyBinds.CameraMoveUp*/))
            {
                System.Console.WriteLine("W");
                cameraMovement.Y = -moveSpeed;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.S/*KeyBinds.CameraMoveDown*/))
            {
                System.Console.WriteLine("S");
                cameraMovement.Y = moveSpeed;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.A/*KeyBinds.CameraMoveLeft*/))
            {
                System.Console.WriteLine("A");
                cameraMovement.X = -moveSpeed;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D/*KeyBinds.CameraMoveRight*/))
            {
                System.Console.WriteLine("D");
                cameraMovement.X = moveSpeed;
            }

            previousMouseWheelValue = currentMouseWheelValue;
            currentMouseWheelValue = Mouse.GetState().ScrollWheelValue;

            if(currentMouseWheelValue > previousMouseWheelValue)
            {
                AdjustZoom(.05f);
                System.Console.WriteLine(moveSpeed);
            }

            if(currentMouseWheelValue < previousMouseWheelValue)
            {
                AdjustZoom(-.05f);
                System.Console.WriteLine(moveSpeed);
            }

            previousZoom = currentZoom;
            currentZoom = Zoom;

            if( previousZoom != currentZoom)
            {
                System.Console.WriteLine(currentZoom);
            }

            MoveCamera(cameraMovement);
        }
    }
}
