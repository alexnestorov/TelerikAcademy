using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ExtractArtistsXPath
{
    public class Startup
    {
        public static void Main()
        {
            string path = "../../../catalogue.xml";
            var artistsAndAlbums = new Dictionary<string, int>();

            GetAllArtistsAndAlbumsXPath(path, artistsAndAlbums);
            PrintResult(artistsAndAlbums);
        }

        private static IDictionary<string, int> GetAllArtistsAndAlbumsXPath(string path, IDictionary<string, int> artistsAndAlbums)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            string xPathArtist = "catalogue/album/artist";

            XmlNodeList artists = doc.SelectNodes(xPathArtist);

            foreach (XmlNode artist in artists)
            {
                if (!artistsAndAlbums.ContainsKey(artist.InnerText))
                {
                    artistsAndAlbums.Add(artist.InnerText, 1);
                    continue;
                }
                artistsAndAlbums[artist.InnerText] += 1;
            }

            return artistsAndAlbums;
        }

        private static void PrintResult(IDictionary<string, int> currentAlbums)
        {
            Console.WriteLine("XPath artists:");
            Console.WriteLine(string.Join(Environment.NewLine, currentAlbums.OrderBy(x => x.Value)));
        }
    }
}
