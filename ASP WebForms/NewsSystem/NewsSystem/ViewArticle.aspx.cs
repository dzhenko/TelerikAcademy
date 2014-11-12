namespace NewsSystem
{
    using System;
    using System.Linq;
    using System.Web.ModelBinding;

    using Microsoft.AspNet.Identity;

    using NewsSystem.Models;
    using NewsSystem.Controls;

    public partial class ViewArticle : BasePage
    {
        protected int GetLikesCount(Article article)
        {
            return article.Likes.Count(l => l.Value == true) - article.Likes.Count(l => l.Value == false);
        }

        protected bool? GetUserVote(Article article)
        {
            var like = article.Likes.FirstOrDefault(l => l.UserId == User.Identity.GetUserId());
            if (like == null)
            {
                return null;
            }

            return like.Value;
        } 

        public Article FormViewBook_GetItem([QueryString("id")]int? articleId)
        {
            if (articleId == null)
            {
                Response.Redirect("~/");
            }

            var book = this.Data.Articles.Find(articleId);

            if (book == null)
            {
                Response.Redirect("~/");
            }

            return book;
        }

        protected void LikeControl_ButtonClicked(object sender, LikeControlEventArgs e)
        {
            var articleId = Convert.ToInt32(e.ArticleId);
            var userId = User.Identity.GetUserId();

            var like = this.Data.Likes.FirstOrDefault(l => l.ArticleId == articleId && l.UserId == userId);
            if (like == null)
            {
                this.Data.Likes.Add(new Like() { UserId = userId, ArticleId = articleId, Value=e.Liked });
            }
            else
            {
                like.Value = e.Liked;
            }

            this.Data.SaveChanges();

            this.FormViewArticle.DataBind();
        }
    }
}