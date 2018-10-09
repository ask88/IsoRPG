using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Xml;

namespace PrototypeGame2.INPUT
{
    public class GamepadInput
    {

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

        private GamePadState actionOldState;
        private GamePadState cancelOldState;
        private GamePadState upOldState;
        private GamePadState downOldState;
        private GamePadState leftOldState;
        private GamePadState rightOldState;
        private GamePadState cameraZoomInOldState;
        private GamePadState cameraZoomOutOldState;
        private GamePadState cameraRotateClockWiseOldState;
        private GamePadState cameraRotateCounterClockWiseOldState;

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
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(action) && actionOldState.IsButtonUp(action))
            {
                pressed = true;
            }
            actionOldState = state;
            return pressed;
        }

        public bool cancelBtn()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(cancel) && cancelOldState.IsButtonUp(cancel))
            {
                pressed = true;
            }
            cancelOldState = state;
            return pressed;
        }

        public bool upBtn()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(up) && upOldState.IsButtonUp(up))
            {
                pressed = true;
            }
            upOldState = state;
            return pressed;
        }

        public bool downBtn()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(action) && downOldState.IsButtonUp(down))
            {
                pressed = true;
            }
            downOldState = state;
            return pressed;
        }

        public bool leftBtn()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(left) && downOldState.IsButtonUp(left))
            {
                pressed = true;
            }
            leftOldState = state;
            return pressed;
        }

        public bool rightBtn()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(right) && downOldState.IsButtonUp(right))
            {
                pressed = true;
            }
            rightOldState = state;
            return pressed;
        }

        public bool zoomInBtn()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(cameraZoomIn) && downOldState.IsButtonUp(cameraZoomIn))
            {
                pressed = true;
            }
            cameraZoomInOldState = state;
            return pressed;
        }

        public bool zoomOutBtn()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(cameraZoomOut) && downOldState.IsButtonUp(cameraZoomOut))
            {
                pressed = true;
            }
            cameraZoomOutOldState = state;
            return pressed;
        }

        public bool rotateCameraCW_Btn()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(cameraRotateClockWise) && downOldState.IsButtonUp(cameraRotateClockWise))
            {
                pressed = true;
            }
            cameraRotateClockWiseOldState = state;
            return pressed;
        }

        public bool rotateCameraCCW_Btn()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool pressed = false;

            if (state.IsButtonDown(cameraRotateCounterClockWise) && downOldState.IsButtonUp(cameraRotateCounterClockWise))
            {
                pressed = true;
            }
            cameraRotateCounterClockWiseOldState = state;
            return pressed;
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
