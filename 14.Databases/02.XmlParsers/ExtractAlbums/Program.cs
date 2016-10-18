using System;
using System.Xml;

namespace ExtractAlbums
{
    public class Program
    {
        public static void Main()
        {
            string inputFile = "../../../catalogue.xml";
            string outputFile = "../../../result/artist-albums.xml";
            XmlWriterSettings settings = new XmlWriterSettings();

            GenerateAlbumsAndAuthors(settings, inputFile, outputFile);
            Console.WriteLine("Document has been exported successfully.");
        }

        private static void GenerateAlbumsAndAuthors(XmlWriterSettings objectSettings, string input, string output)
        {
            objectSettings.Indent = true;
            objectSettings.NewLineOnAttributes = true;

            var reader = XmlReader.Create(input);
            using (reader)
            {
                var writer = XmlWriter.Create(output, objectSettings);
                using (writer)
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            if (reader.Name == "album")
                            {
                                writer.WriteStartElement("album");
                            }
                            else if (reader.Name == "name")
                            {
                                reader.Read();
                                writer.WriteElementString("name", reader.Value);
                            }
                            else if (reader.Name == "artist")
                            {
                                reader.Read();
                                writer.WriteElementString("artist", reader.Value);
                            }
                        }

                        if (!reader.IsStartElement())
                        {
                            if (reader.Name == "album")
                            {
                                writer.WriteEndElement();
                            }
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }
    }
}
