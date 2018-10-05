using Microsoft.Xna.Framework.Input;
using System;
using System.Xml;

namespace PrototypeGame2.INPUT
{
    public class KeyboardInput
    {
        private KeyboardState newState;
        private KeyboardState oldState;

        public static Keys action;
        public static Keys cancel;
        public static Keys up;
        public static Keys down;
        public static Keys left;
        public static Keys right;
        public static Keys cameraZoomIn;
        public static Keys cameraZoomOut;
        public static Keys cameraRotateClockWise;
        public static Keys cameraRotateCounterClockWise;

        public bool isZoomed = false;

        public KeyboardInput()
        {
            action = Keys.Space;
            cancel = Keys.Back;
            up = Keys.W;
            down = Keys.S;
            left = Keys.A;
            right = Keys.D;
            cameraZoomIn = Keys.Up;
            cameraZoomOut = Keys.Down;
            cameraRotateClockWise = Keys.Right;
            cameraRotateCounterClockWise = Keys.Left;
        }

        public void readButtonMap()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("keymap.xml");

            Enum.TryParse(getAttributeValue(xml, "Key", "action"), out action);
            Enum.TryParse(getAttributeValue(xml, "Key", "cancel"), out cancel);
            Enum.TryParse(getAttributeValue(xml, "Key", "up"), out up);
            Enum.TryParse(getAttributeValue(xml, "Key", "down"), out down);
            Enum.TryParse(getAttributeValue(xml, "Key", "left"), out left);
            Enum.TryParse(getAttributeValue(xml, "Key", "right"), out right);
            Enum.TryParse(getAttributeValue(xml, "Key", "cameraZoomIn"), out cameraZoomIn);
            Enum.TryParse(getAttributeValue(xml, "Key", "cameraZoomOut"), out cameraZoomOut);
            Enum.TryParse(getAttributeValue(xml, "Key", "cameraRotateClockWise"), out cameraRotateClockWise);
            Enum.TryParse(getAttributeValue(xml, "Key", "cameraRotateCounterClockWise"), out cameraRotateCounterClockWise);
        }

        public bool actionBtn()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(action) && oldState.IsKeyUp(action))
            {
                return true;
            }

            return false;
        }

        public bool cancelBtn()
        {
            newState = Keyboard.GetState();
            if(newState.IsKeyDown(cancel) && oldState.IsKeyUp(cancel))
            {
                return true;
            }
            oldState = Keyboard.GetState();
            return false;
        }

        public bool upBtn()
        {
            newState = Keyboard.GetState();
            if(newState.IsKeyDown(up) && oldState.IsKeyUp(up))
            {
                return true;
            }
            oldState = Keyboard.GetState();
            return false;
        }

        public bool downBtn()
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(down) && oldState.IsKeyUp(down))
            {
                return true;
            }

            oldState = Keyboard.GetState();
            return false;
        }

        public bool leftBtn()
        {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(left) && oldState.IsKeyUp(left))
            {
                return true;
            }
            oldState = Keyboard.GetState();
            return false;
        }

        public bool rightBtn()
        {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(right) && oldState.IsKeyUp(right))
            {
                return true;
            }
            oldState = Keyboard.GetState();
            return false;
        }

        public bool zoomInBtn()
        {
            newState = Keyboard.GetState();
            if(newState.IsKeyDown(cameraZoomIn) && oldState.IsKeyUp(cameraZoomIn) && !isZoomed)
            {
                return true;
            }
            oldState = Keyboard.GetState();
            return false;
        }

        public bool zoomOutBtn()
        {
            newState = Keyboard.GetState();
            if(newState.IsKeyDown(cameraZoomOut) && oldState.IsKeyUp(cameraZoomOut) && isZoomed)
            {
                return true;
            }
            oldState = Keyboard.GetState();
            return false;
        }

        public bool rotateCameraCW_Btn()
        {
            newState = Keyboard.GetState();
            if(newState.IsKeyDown(cameraRotateClockWise) && oldState.IsKeyUp(cameraRotateClockWise))
            {
                return true;
            }
            oldState = Keyboard.GetState();
            return false;
        }

        public bool rotateCameraCCW_Btn()
        {
            newState = Keyboard.GetState();
            if(newState.IsKeyDown(cameraRotateCounterClockWise) && oldState.IsKeyUp(cameraRotateCounterClockWise))
            {
                return true;
            }
            oldState = Keyboard.GetState();
            return false;
        }

        private string getAttributeValue(XmlDocument xmlDoc, string element, string attribute)
        {
            XmlNodeList map = xmlDoc.GetElementsByTagName(element);
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Attributes.Count; j++)
                {
                    if (map[i].Attributes[j].Name.Equals(attribute))
                    {
                        return map[i].Attributes[j].Value;
                    }
                }
            }
            return null;
        }

        public static Keys getAction() { return action; }
        public static Keys getCancel() { return cancel; }
        public static Keys getUp() { return up; }
        public static Keys getDown() { return down; }
        public static Keys getLeft() { return left; }
        public static Keys getRight() { return right; }
        public static Keys getCameraZoomIn() { return cameraZoomIn; }
        public static Keys getCameraZoomOut() { return cameraZoomOut; }
        public static Keys getCameraRotateCW() { return cameraRotateClockWise; }
        public static Keys getCameraRotateCCW() { return cameraRotateCounterClockWise; }

        public void setAction(Keys action) { KeyboardInput.action = action; }
        public void setCancel(Keys cancel) { KeyboardInput.cancel = cancel; }
        public void setUp(Keys up) { KeyboardInput.up = up; }
        public void setDown(Keys down) { KeyboardInput.down = down; }
        public void setLeft(Keys left) { KeyboardInput.left = left; }
        public void setRight(Keys right) { KeyboardInput.right = right; }
        public void setCameraZoomIn(Keys cameraZoomIn) { KeyboardInput.cameraZoomIn = cameraZoomIn; }
        public void setCameraZoomOut(Keys cameraZoomOut) { KeyboardInput.cameraZoomOut = cameraZoomOut; }
        public void setCameraRotateCW(Keys cameraRotateClockWise) { KeyboardInput.cameraRotateClockWise = cameraRotateClockWise; }
        public void setCameraRotateCCW(Keys cameraRotateCounterClockWise) { KeyboardInput.cameraRotateCounterClockWise = cameraRotateCounterClockWise; }
    }
}
