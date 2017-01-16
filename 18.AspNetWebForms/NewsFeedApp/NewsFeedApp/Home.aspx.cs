using NewsFeedApp.Data.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsFeedApp
{
    public partial class Home : System.Web.UI.Page
    {
        [Inject]
        public IArticleService ArticleService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<NewsFeedApp.Data.Models.Article> repeaterArticle_GetData()
        {
            return this.ArticleService.GetTop(5);
        }
    }
}