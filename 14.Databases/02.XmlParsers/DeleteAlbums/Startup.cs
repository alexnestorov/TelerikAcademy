using System;
using System.Xml;

namespace DeleteAlbums
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int price = 20;
            string path = "../../../catalogue.xml";
            XmlDocument saveDocument = new XmlDocument();
            XmlDocument loadDocument = new XmlDocument();

            DeleteAllOverAPriceDOM(saveDocument, loadDocument, path, price);

            PrintResult(saveDocument);
        }

        private static void DeleteAllOverAPriceDOM(XmlDocument currentDocument, XmlDocument loadDocument, string path, int maxPrice)
        {
            loadDocument.Load(path);

            XmlDeclaration xmlDeclaration = currentDocument.CreateXmlDeclaration("1.0", "utf-8", null);

            // Create root node
            var rootNode = loadDocument.DocumentElement;
            XmlElement rootElement = currentDocument.CreateElement(rootNode.Name);
            currentDocument.AppendChild(rootElement);

            // Add xml declaration
            currentDocument.InsertBefore(xmlDeclaration, currentDocument.DocumentElement);

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                var price = child["price"];
                if (price != null && decimal.Parse(price.InnerText) < maxPrice)
                {
                    rootElement.AppendChild(currentDocument.ImportNode(child, true));
                }
            }
        }

        private static void PrintResult(XmlDocument currentDocument)
        {
            currentDocument.Save("../../../result/cheap-albums.xml");
            Console.WriteLine("Document has been successfully saved.");
        }
    }
}
