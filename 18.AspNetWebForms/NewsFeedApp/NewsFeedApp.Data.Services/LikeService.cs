using NewsFeedApp.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeedApp.Data.Models;

namespace NewsFeedApp.Data.Services
{
    public class LikeService : ILikeService
    {
        public void ChangeLike(string userId, int articleId)
        {
            throw new NotImplementedException();
        }

        public void CreateLike(Like like)
        {
            throw new NotImplementedException();
        }

        public Like GetByAuthorIdAndArticledId(string userId, int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
