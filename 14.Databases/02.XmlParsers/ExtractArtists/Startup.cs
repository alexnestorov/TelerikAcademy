using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ExtractArtists
{
    public class Startup
    {
        public static void Main()
        {
            string pathXmlFile = "../../../catalogue.xml";
            var currentAlbums = new Dictionary<string, int>();

            GetAllArtistsAndAlbums(pathXmlFile, currentAlbums);
            PrintResult(currentAlbums);
        }

        private static void GetAllArtistsAndAlbums(string path, IDictionary<string, int> artistsAndAlbums)
        {
            XmlDocument currentDocument = new XmlDocument();
            currentDocument.Load(path);

            var rootNode = currentDocument.DocumentElement;

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                var artist = child["artist"];

                if (artist != null)
                {
                    if (!artistsAndAlbums.ContainsKey(artist.InnerText))
                    {
                        artistsAndAlbums.Add(artist.InnerText, 1);
                        continue;
                    }

                    artistsAndAlbums[artist.InnerText] += 1;
                }
            }
        }

        private static void PrintResult(IDictionary<string, int> currentAlbums)
        {
            Console.WriteLine("Dom artists:");
            Console.WriteLine(string.Join(Environment.NewLine, currentAlbums.OrderBy(x => x.Value)));
        }
    }
}
