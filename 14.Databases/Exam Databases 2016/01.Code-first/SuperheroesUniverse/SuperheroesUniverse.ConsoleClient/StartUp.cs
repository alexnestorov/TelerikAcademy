using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Migrations;
using SuperheroesUniverse.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.ConsoleClient
{
    public class StartUp
    {
        private const string SavePathFile = @"..\..\..\..\SampleData";

        public static void Main()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperheroesUniverseDbContext, Configuration>());
            Database.SetInitializer<SuperheroesUniverseDbContext>(new MigrateDatabaseToLatestVersion<SuperheroesUniverseDbContext, Configuration>());

            var db = new SuperheroesUniverseDbContext();
            var queries = new SuperheroesUniverseExporter();

            queries.ExportAllSuperheroes(SavePathFile);
            queries.ExportSuperheroesByCity("NewYork");
            queries.ExportSuperheroDetails(1);
        }
    }
}
