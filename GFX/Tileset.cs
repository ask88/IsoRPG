using Microsoft.Xna.Framework.Graphics;
using System.Xml;

namespace PrototypeGame2
{
    public class Tileset
    {
        string orientation, renderOrder, tileLayer;
        int width, height, tileWidth, tileHeight, infinite, nextObjectID, tileLayerWidth, tileLayerHeight;
        int[] tileArray;

        public Tileset(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Content/XML/Levels/" + path + ".xml");

            orientation = getAttributeValue(xmlDoc, "map", "orientation");
            renderOrder = getAttributeValue(xmlDoc, "map", "renderorder");
            width = System.Convert.ToInt32(getAttributeValue(xmlDoc, "map", "width"));
            height = System.Convert.ToInt32(getAttributeValue(xmlDoc, "map", "height"));
            tileWidth = System.Convert.ToInt32(getAttributeValue(xmlDoc, "map", "tilewidth"));
            tileHeight = System.Convert.ToInt32(getAttributeValue(xmlDoc, "map", "tileheight"));
            infinite = System.Convert.ToInt32(getAttributeValue(xmlDoc, "map", "infinite"));
            nextObjectID = System.Convert.ToInt32(getAttributeValue(xmlDoc, "map", "nextobjectid"));
            tileLayer = getAttributeValue(xmlDoc, "layer", "name");
            tileLayerWidth = System.Convert.ToInt32(getAttributeValue(xmlDoc, "layer", "width"));
            tileLayerHeight = System.Convert.ToInt32(getAttributeValue(xmlDoc, "layer", "height"));
            tileArray = dataArray(xmlDoc, xmlDoc.GetElementsByTagName("data"));
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

        private int[] dataArray(XmlDocument xmlDoc, XmlNodeList xmlNode)
        {
            int count = 0;

            for (int i = 0; i < xmlNode.Count; i++)
            {
                for (int k = 0; k < xmlNode[i].Attributes.Count; k++)
                {
                    for (int j = 0; j < xmlNode[i].FirstChild.Value.Length; j++)
                    {
                        if (isDigit(xmlNode[i].FirstChild.Value[j]))
                        {
                            count++;
                        }
                    }
                }
            }

            int[] tileArray = new int[count];

            count = 0;
            for (int i = 0; i < xmlNode.Count; i++)
            {
                for (int k = 0; k < xmlNode[i].Attributes.Count; k++)
                {
                    for (int j = 0; j < xmlNode[i].FirstChild.Value.Length; j++)
                    {
                        if (isDigit(xmlNode[i].FirstChild.Value[j]))
                        {
                            tileArray[count] = (int)char.GetNumericValue(xmlNode[i].FirstChild.Value[j]);
                            count++;
                        }
                    }
                }
            }

            return tileArray;
        }

        private bool isDigit(char x)
        {
            
            string num = "1234567890";
            bool digit = false;

            for (int i = 0; i < num.Length; i++)
            {
                if (x.Equals(num[i]))
                {
                    digit = true;
                    break;
                }
                else
                {
                    digit = false;
                }
            }

            return digit;
        }

        public void update(float UC)
        {

        }

        public void draw(SpriteBatch sp, float UC)
        {

        }

        public int getWidth() { return width; }
        public int getHeight() { return height; }
        public int getTileWidth() { return tileWidth; }
        public int getTileHeight() { return tileHeight; }
        public bool isInfinite()
        {
            if(infinite == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getNextObjectID() { return nextObjectID; }
        public int[] getTileArray() { return tileArray; }
        public string getTileLayer() { return tileLayer; }
        public int getTileLayerWidth() { return tileLayerWidth; }
        public int getTileLayerHeight() { return tileLayerHeight; }
    }
}
