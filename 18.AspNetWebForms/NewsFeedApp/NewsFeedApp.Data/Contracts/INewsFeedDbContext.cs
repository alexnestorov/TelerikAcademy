using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using NewsFeedApp.Data.Models;

namespace NewsFeedApp.Data.Contracts
{
    public interface INewsFeedDbContext : IDisposable
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Article> Articles { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Like> Likes { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
