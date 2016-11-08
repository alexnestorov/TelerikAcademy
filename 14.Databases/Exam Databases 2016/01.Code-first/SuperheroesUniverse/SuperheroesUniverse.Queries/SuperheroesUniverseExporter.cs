using SuperheroesUniverse.Data;
using SuperheroesUniverse.Queries.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SuperheroesUniverse.Queries
{
    public class SuperheroesUniverseExporter
    {
        private const string RootNameSuperheroes = "Superheroes";
        private const string SavePathFile = @"..\..\..\..\SampleData";

        public void ExportAllSuperheroes(string fileOutput)
        {
            string FileName = "Superheroes.xml";

            XmlDocument report = new XmlDocument();
            XmlDeclaration xmlDeclaration = report.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = report.CreateElement(RootNameSuperheroes);
            report.AppendChild(root);
            report.InsertBefore(xmlDeclaration, root);

            using (var db = new SuperheroesUniverseDbContext())
            {
                var superheroes = db.Superheroes.Select(s => s).ToList();

                foreach (var sh in superheroes)
                {
                    XmlElement superhero = report.CreateElement("Superhero");
                    superhero.SetAttribute("name", sh.Name);
                    superhero.SetAttribute("secretIdentity", sh.SecretIdentity);
                    superhero.SetAttribute("alignment", sh.Allignment.ToString());
                    foreach (var p in sh.Powers)
                    {
                        XmlElement power = report.CreateElement("Power");
                        power.SetAttribute("power", p.Name);
                        superhero.AppendChild(power);
                    }
                    superhero.SetAttribute("city", sh.City.Name);
                    root.AppendChild(superhero);

                }
            }

            report.Save(SavePathFile + FileName);
        }

        public string ExportFractionDetails(object fractionId)
        {
            throw new NotImplementedException();
        }

        public string ExportFractions()
        {
            throw new NotImplementedException();
        }

        public void ExportSuperheroDetails(object superheroId)
        {
            string FileName = "SuperheroesById.xml";

            XmlDocument report = new XmlDocument();
            XmlDeclaration xmlDeclaration = report.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = report.CreateElement(RootNameSuperheroes);
            report.AppendChild(root);
            report.InsertBefore(xmlDeclaration, root);

            using (var db = new SuperheroesUniverseDbContext())
            {
                var id = int.Parse(superheroId.ToString());
                var superheroes = db.Superheroes.Select(x => x).Where(c => c.Id == id).ToList();


                foreach (var sh in superheroes)
                {
                    Console.WriteLine(sh.City.Name);
                    XmlElement superhero = report.CreateElement("Superhero");
                    superhero.SetAttribute("name", sh.Name);
                    superhero.SetAttribute("secretIdentity", sh.SecretIdentity);
                    superhero.SetAttribute("alignment", sh.Allignment.ToString());
                    foreach (var p in sh.Powers)
                    {
                        XmlElement power = report.CreateElement("Power");
                        power.SetAttribute("power", p.Name);
                        superhero.AppendChild(power);
                    }
                    superhero.SetAttribute("city", sh.City.Name);
                    root.AppendChild(superhero);

                }
                report.Save(SavePathFile + FileName);
            }
        }

        public void ExportSuperheroesByCity(string cityName)
        {
            string FileName = "SuperheroesByCity.xml";

            XmlDocument report = new XmlDocument();
            XmlDeclaration xmlDeclaration = report.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = report.CreateElement(RootNameSuperheroes);
            report.AppendChild(root);
            report.InsertBefore(xmlDeclaration, root);

            using (var db = new SuperheroesUniverseDbContext())
            {
                var superheroes = db.Superheroes.Select(x=> x).Where(c => c.City.Name == cityName).ToList();


                foreach (var sh in superheroes)
                {
                    Console.WriteLine(sh.City.Name);
                    XmlElement superhero = report.CreateElement("Superhero");
                    superhero.SetAttribute("name", sh.Name);
                    superhero.SetAttribute("secretIdentity", sh.SecretIdentity);
                    superhero.SetAttribute("alignment", sh.Allignment.ToString());
                    foreach (var p in sh.Powers)
                    {
                        XmlElement power = report.CreateElement("Power");
                        power.SetAttribute("power", p.Name);
                        superhero.AppendChild(power);
                    }
                    superhero.SetAttribute("city", sh.City.Name);
                    root.AppendChild(superhero);

                }
            }

            report.Save(SavePathFile + FileName);
        }

        public string ExportSupperheroesWithPower(string power)
        {
            throw new NotImplementedException();
        }
    }
}
