using System.Linq;

using NewsFeedApp.Data.Models;

namespace NewsFeedApp.Data.Services.Contracts
{
    public interface IArticleService
    {
        IQueryable<Article> GetTop(int count);

        IQueryable<Article> GetAll();

        Article GetById(int id);

        void UpdateById(int id, Article updateArticle);

        void DeleteById(int id);

        void Create(Article article);
    }
}
