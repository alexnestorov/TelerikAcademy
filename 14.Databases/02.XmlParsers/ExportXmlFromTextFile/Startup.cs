using System;
using System.IO;
using System.Xml.Linq;

namespace ExportXmlFromTextFile
{
   public class Startup
    {
        public static void Main(string[] args)
        {
            string input = "../../../people.txt";
            string output = "../../../result/extracted-people.xml";

            GenerateXmlFromTextFile(input, output);
        }

        private static void GenerateXmlFromTextFile(string input, string output)
        {
            StreamReader reader = new StreamReader(input);

            var xml = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            var root = new XElement("people");

            var currentline = reader.ReadLine();

            while (currentline.Equals(null))
            {
                var currentPerson = new XElement("person");
                currentPerson.Add(new XElement("name", currentline));
                currentline = reader.ReadLine();

                currentPerson.Add(new XElement("address", currentline));
                currentline = reader.ReadLine();

                currentPerson.Add(new XElement("phone", currentline));
                currentline = reader.ReadLine();

                root.Add(currentPerson);
            }

            xml.Add(root);

            Console.WriteLine(xml);

            xml.Save(output);
        }
    }
}
