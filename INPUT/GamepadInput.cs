using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Xml;

namespace PrototypeGame2.INPUT
{
    public class GamepadInput
    {
        private GamePadState newState;
        private GamePadState oldState;

        public static Buttons action;
        public static Buttons cancel;
        public static Buttons up;
        public static Buttons down;
        public static Buttons left;
        public static Buttons right;
        public static Buttons cameraZoomIn;
        public static Buttons cameraZoomOut;
        public static Buttons cameraRotateClockWise;
        public static Buttons cameraRotateCounterClockWise;

        public bool isZoomed = false;

        public GamepadInput()
        {
            action = Buttons.A;
            cancel = Buttons.B;
            up = Buttons.DPadUp;
            down = Buttons.DPadDown;
            left = Buttons.DPadLeft;
            right = Buttons.DPadRight;
            cameraZoomIn = Buttons.RightShoulder;
            cameraZoomOut = Buttons.LeftShoulder;
            cameraRotateClockWise = Buttons.RightTrigger;
            cameraRotateCounterClockWise = Buttons.LeftTrigger;
        }

        public void readButtonMap()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("keymap.xml");

            Enum.TryParse(getAttributeValue(xml, "Button", "action"), out action);
            Enum.TryParse(getAttributeValue(xml, "Button", "cancel"), out cancel);
            Enum.TryParse(getAttributeValue(xml, "Button", "up"), out up);
            Enum.TryParse(getAttributeValue(xml, "Button", "down"), out down);
            Enum.TryParse(getAttributeValue(xml, "Button", "left"), out left);
            Enum.TryParse(getAttributeValue(xml, "Button", "right"), out right);
            Enum.TryParse(getAttributeValue(xml, "Button", "cameraZoomIn"), out cameraZoomIn);
            Enum.TryParse(getAttributeValue(xml, "Button", "cameraZoomOut"), out cameraZoomOut);
            Enum.TryParse(getAttributeValue(xml, "Button", "cameraRotateClockWise"), out cameraRotateClockWise);
            Enum.TryParse(getAttributeValue(xml, "Button", "cameraRotateCounterClockWise"), out cameraRotateCounterClockWise);

        }


        public bool actionBtn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if(newState.IsButtonDown(action) && newState.IsButtonUp(action))
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
            return false;
        }

        public bool cancelBtn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsButtonDown(cancel) && oldState.IsButtonUp(cancel))
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
            return false;
        }

        public bool upBtn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsButtonDown(up) && oldState.IsButtonUp(up))
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
            return false;
        }

        public bool downBtn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsButtonDown(down) && oldState.IsButtonUp(down))
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
            return false;
        }

        public bool leftBtn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsButtonDown(left) && oldState.IsButtonUp(left))
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
            return false;
        }

        public bool rightBtn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsButtonDown(right) && oldState.IsButtonUp(right))
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
            return false;
        }

        public bool zoomInBtn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsButtonDown(cameraZoomIn) && oldState.IsButtonUp(cameraZoomIn) && !isZoomed)
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
            return false;
        }

        public bool zoomOutBtn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsButtonDown(cameraZoomOut) && oldState.IsButtonUp(cameraZoomOut) && isZoomed)
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
            return false;
        }

        public bool rotateCameraCW_Btn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsButtonDown(cameraRotateClockWise) && oldState.IsButtonUp(cameraRotateClockWise))
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
            return false;
        }

        public bool rotateCameraCCW_Btn()
        {
            newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsButtonDown(cameraRotateCounterClockWise) && oldState.IsButtonUp(cameraRotateCounterClockWise))
            {
                return true;
            }
            oldState = GamePad.GetState(PlayerIndex.One);
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

        public static Buttons getAction() { return action; }
        public static Buttons getCancel() { return cancel; }
        public static Buttons getUp() { return up; }
        public static Buttons getDown() { return down; }
        public static Buttons getLeft() { return left; }
        public static Buttons getRight() { return right; }
        public static Buttons getCameraZoomIn() { return cameraZoomIn; }
        public static Buttons getCameraZoomOut() { return cameraZoomOut; }
        public static Buttons getCameraRotateCW() { return cameraRotateClockWise; }
        public static Buttons getCameraRotateCCW() { return cameraRotateCounterClockWise; }

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
