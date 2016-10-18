using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace JsonParsingVideos
{
    public class Program
    {
        public static void Main()
        {
            string fileLocation = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            string downloadLocation = "../../../telerik-rss.xml";

            // Download the file
            DownloadFile(fileLocation, downloadLocation);

            // Parse the xml to json
            var doc = XDocument.Load(downloadLocation);
            var json = JsonConvert.SerializeXNode(doc, Formatting.Indented);

            // Convert to POCOs
            var jsonObject = JObject.Parse(json);
            var videos = jsonObject["feed"]["entry"].Select(e => JsonConvert.DeserializeObject<Video>(e.ToString()));


            // HTML
            var htmlResult = GenerateHtml(videos);

            // Save File
            File.WriteAllText("../../../index.html", htmlResult, Encoding.UTF8);

            Console.WriteLine("File generated");

        }

        private static string GenerateHtml(IEnumerable<Video> videos)
        {
            var htmlString = new StringBuilder();

            htmlString.Append("<!DOCTYPE html>");
            htmlString.Append("<html><head><title>Telerik Latest Videos</title></head><body>");

            foreach (var video in videos)
            {
                htmlString.AppendFormat(
                    "<div style=\"background:grey; color:white; width:450px; padding:10px; margin:10px;\"><h3><a style=\"text-decoration:none; color:white;\" href=\"{0}\">{1}</a></h3><iframe width=\"420\" height=\"315\" src=\"http://www.youtube.com/embed/{2}?autoplay=0\"></iframe><h3>{3}</h3></div>",
                    video.Link.Href,
                    video.Title,
                    video.Id,
                    video.Published.ToShortDateString());
            }

            htmlString.Append("</body></html>");
            return htmlString.ToString();
        }

        private static void DownloadFile(string fileLocation, string downloadLocation)
        {
            var client = new WebClient();
            try
            {
                using (client)
                {
                    client.DownloadFile(fileLocation, downloadLocation);
                }
            }

            catch (WebException)
            {
                Console.WriteLine("Wrong file name or no internet connection!");
            }
        }
    }
}
