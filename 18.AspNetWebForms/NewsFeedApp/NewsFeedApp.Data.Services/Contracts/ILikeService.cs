using NewsFeedApp.Data.Models;

namespace NewsFeedApp.Data.Services.Contracts
{
    public interface ILikeService
    {
        Like GetByAuthorIdAndArticledId(string userId, int articleId);

        void ChangeLike(string userId, int articleId);

        void CreateLike(Like like);
    }
}
