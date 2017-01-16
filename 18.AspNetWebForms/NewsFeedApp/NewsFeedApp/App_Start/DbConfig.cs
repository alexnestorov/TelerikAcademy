using NewsFeedApp.Data;
using NewsFeedApp.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewsFeedApp.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsFeedDbContext, Configuration>());
            NewsFeedDbContext.Create().Database.Initialize(true);
        }
    }
}