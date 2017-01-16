using NewsFeedApp.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeedApp.Data.Models;

namespace NewsFeedApp.Data.Services
{
    public class CategoryService : ICategoryService
    {
        public Category Create(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void UpdateNameById(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
