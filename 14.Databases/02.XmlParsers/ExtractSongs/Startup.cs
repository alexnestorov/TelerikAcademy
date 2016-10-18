using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ExtractSongs
{
    public class Startup
    {
        private static void Main(string[] args)
        {
            string path = "../../../catalogue.xml";
            var songs = GetSongsNameLinq(path);
            PrintResult(songs);
        }

        private static IEnumerable<string> GetSongsNameLinq(string path)
        {
            var xml = XDocument.Load(path);

            var songs = xml.Descendants()
                .Where(x => x.Name == "song")
                .OrderBy(x => x.Attribute("title").ToString())
                .Select(x => x.Attribute("title").Value);

            foreach (var item in songs)
            {
                Console.WriteLine(item);
            }

            return songs;
        }

        private static void PrintResult(IEnumerable<string> values)
        {
            Console.WriteLine(string.Join(Environment.NewLine, values));
        }
    }
}
