using System.Linq;

using NewsFeedApp.Data.Models;

namespace NewsFeedApp.Data.Services.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();

        Category Create(string name);

        void UpdateNameById(int id, string name);

        void DeleteId(int id);
    }
}
