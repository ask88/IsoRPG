using Microsoft.Xna.Framework.Input;
using System;
using System.Xml;

namespace PrototypeGame2.INPUT
{

    public class KeyboardInput
    {
        
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

        private KeyboardState actionOldState;
        private KeyboardState cancelOldState;
        private KeyboardState upOldState;
        private KeyboardState downOldState;
        private KeyboardState leftOldState;
        private KeyboardState rightOldState;
        private KeyboardState cameraZoomInOldState;
        private KeyboardState cameraZoomOutOldState;
        private KeyboardState cameraRotateClockWiseOldState;
        private KeyboardState cameraRotateCounterClockWiseOldState;

        public KeyboardInput()
        {
            action = Keys.Enter;
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
            bool pressed = false;

            if (state.IsKeyDown(action) && actionOldState.IsKeyUp(action))
            {
                pressed = true;
            }
            actionOldState = state;
            return pressed;
        }

        public bool cancelBtn()
        {
            KeyboardState state = Keyboard.GetState();
            bool pressed = false;

            if(state.IsKeyDown(cancel) && cancelOldState.IsKeyUp(cancel))
            {
                pressed = true;
            }
            cancelOldState = state;
            return pressed;
        }

        public bool upBtn()
        {
            KeyboardState state = Keyboard.GetState();
            bool pressed = false;

            if(state.IsKeyDown(up) && upOldState.IsKeyUp(up))
            {
                pressed = true;
            }

            upOldState = state;
            return pressed;
        }

        public bool downBtn()
        {
            KeyboardState state = Keyboard.GetState();
            bool pressed = false;

            if (state.IsKeyDown(down) && downOldState.IsKeyUp(down))
            { 
                pressed = true;
            }

            downOldState = state;
            return pressed;
        }

        public bool leftBtn()
        {
            KeyboardState state = Keyboard.GetState();
            bool pressed = false;
            if (state.IsKeyDown(left) && leftOldState.IsKeyUp(left))
            {
                pressed = true;
            }
            leftOldState = state;
            return pressed;
        }

        public bool rightBtn()
        {
            KeyboardState state = Keyboard.GetState();
            bool pressed = false;
            if (state.IsKeyDown(right) && rightOldState.IsKeyUp(right))
            {
                pressed = true;
            }
            rightOldState = state;
            return pressed;
        }

        public bool zoomInBtn()
        {
            KeyboardState state = Keyboard.GetState();
            bool pressed = false;
            if(state.IsKeyDown(cameraZoomIn) && cameraZoomInOldState.IsKeyUp(cameraZoomIn) && !isZoomed)
            {
                pressed = true;
            }
            cameraZoomInOldState = state;
            return pressed;
        }

        public bool zoomOutBtn()
        {
            KeyboardState state = Keyboard.GetState();
            bool pressed = false;
            if(state.IsKeyDown(cameraZoomOut) && cameraZoomOutOldState.IsKeyUp(cameraZoomOut) && isZoomed)
            {
                pressed = true;
            }
            cameraZoomOutOldState = state;
            return pressed;
        }

        public bool rotateCameraCW_Btn()
        {
            KeyboardState state = Keyboard.GetState();
            bool pressed = false;
            if(state.IsKeyDown(cameraRotateClockWise) && cameraRotateClockWiseOldState.IsKeyUp(cameraRotateClockWise))
            {
                pressed = true;
            }
            cameraRotateClockWiseOldState = state;
            return pressed;
        }

        public bool rotateCameraCCW_Btn()
        {
            KeyboardState state = Keyboard.GetState();
            bool pressed = false;
            if(state.IsKeyDown(cameraRotateCounterClockWise) && cameraRotateCounterClockWiseOldState.IsKeyUp(cameraRotateCounterClockWise))
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
