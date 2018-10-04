using System;
using System.Xml;
namespace PrototypeGame2.INPUT
{
    public static class WriteToXML
    {
        public static void write()
        {
            XmlWriter xml = XmlWriter.Create("keymap.xml");

            xml.WriteStartDocument();
            xml.WriteStartElement("ButtonMap");

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("action", Convert.ToString(KeyboardInput.action));
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("cancel", Convert.ToString(KeyboardInput.cancel));
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("up", Convert.ToString(KeyboardInput.up));
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("down", Convert.ToString(KeyboardInput.down));
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("left", Convert.ToString(KeyboardInput.left));
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("right", Convert.ToString(KeyboardInput.right));
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("cameraZoomIn", Convert.ToString(KeyboardInput.cameraZoomIn));
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("cameraZoomOut", Convert.ToString(KeyboardInput.cameraZoomOut));
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("cameraRotateClockWise", Convert.ToString(KeyboardInput.cameraRotateClockWise));
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("cameraRotateCounterClockWise", Convert.ToString(KeyboardInput.cameraRotateCounterClockWise));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("action", Convert.ToString(GamepadInput.action));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("cancel", Convert.ToString(GamepadInput.cancel));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("up", Convert.ToString(GamepadInput.up));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("down", Convert.ToString(GamepadInput.down));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("left", Convert.ToString(GamepadInput.left));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("right", Convert.ToString(GamepadInput.right));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("cameraZoomIn", Convert.ToString(GamepadInput.cameraZoomIn));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("cameraZoomOut", Convert.ToString(GamepadInput.cameraZoomOut));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("cameraRotateClockWise", Convert.ToString(GamepadInput.cameraRotateClockWise));
            xml.WriteEndElement();

            xml.WriteStartElement("Button");
            xml.WriteAttributeString("cameraRotateCounterClockWise", Convert.ToString(GamepadInput.cameraRotateCounterClockWise));
            xml.WriteEndElement();
            xml.Close();
        }
    }
}
