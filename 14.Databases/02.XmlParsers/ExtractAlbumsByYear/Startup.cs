using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExtractAlbumsByYear
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = "../../../catalogue.xml";
            Console.WriteLine("Extracted albums");

            var extractedAlbums = GetAlbumsByYear(20, input);

            Console.WriteLine(string.Join(Environment.NewLine, extractedAlbums));
        }

        private static IEnumerable<Album> GetAlbumsByYear(int yearsBefore, string input)
        {
            var doc = XDocument.Load(input);

            var yearToCompare = DateTime.Now.AddYears(yearsBefore * -1).Year;

            var albums = doc.Descendants("album")
                .Where(x => x.Element("year") != null && int.Parse(x.Element("year").Value) < yearToCompare)
                .Select(x => new Album
                {
                    Name = x.Element("name") != null ? x.Element("name").Value : "N/A",
                    Price = x.Element("price") != null ? x.Element("price").Value : "N/A",

                });

            return albums;
        }
    }
}
