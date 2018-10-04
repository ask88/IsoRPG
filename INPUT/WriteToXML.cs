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
            xml.WriteAttributeString("cancel", "B");
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("up", "W");
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("down", "S");
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("left", "A");
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("right", "D");
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("cameraZoomIn", "Up");
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("cameraZoomOut", "Down");
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("cameraRotateClockWise", "Left");
            xml.WriteEndElement();

            xml.WriteStartElement("Key");
            xml.WriteAttributeString("cameraRotateCounterClockWise", "Right");

            xml.WriteEndElement();
            xml.Close();
        }
    }
}
