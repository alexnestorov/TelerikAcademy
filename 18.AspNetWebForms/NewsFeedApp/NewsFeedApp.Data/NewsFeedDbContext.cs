using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using NewsFeedApp.Data.Contracts;
using NewsFeedApp.Data.Models;

namespace NewsFeedApp.Data
{
    public class NewsFeedDbContext : IdentityDbContext<User>, INewsFeedDbContext
    {
        public NewsFeedDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static NewsFeedDbContext Create()
        {
            return new NewsFeedDbContext();
        }
        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Like> Likes { get; set; }
    }
}
