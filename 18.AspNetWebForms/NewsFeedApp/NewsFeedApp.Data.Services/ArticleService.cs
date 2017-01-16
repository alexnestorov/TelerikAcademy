using NewsFeedApp.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeedApp.Data.Models;
using NewsFeedApp.Data.Contracts;

namespace NewsFeedApp.Data.Services
{
    public class ArticleService : IArticleService
    {
        private IRepository<Article> articles;

        public ArticleService(IRepository<Article> articles)
        {
            this.articles = articles;
        }

        public void Create(Article article)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> GetTop(int count)
        {
            return this.articles.All().OrderBy(x => x.Id).Take(count);
        }

        public void UpdateById(int id, Article updateArticle)
        {
            throw new NotImplementedException();
        }
    }
}
