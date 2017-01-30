using Nortthwind.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeesApp.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Nortthwind.NorthwindEntities, Configuration>());
            Nortthwind.NorthwindEntities.Create().Database.Initialize(true);
        }
    }
}