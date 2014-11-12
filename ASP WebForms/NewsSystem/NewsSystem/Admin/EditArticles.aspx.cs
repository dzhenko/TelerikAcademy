namespace NewsSystem.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.Identity;

    using NewsSystem.Models;
    using System.Web.ModelBinding;
    
    public partial class EditArticles : BasePage
    {
        public IQueryable<Article> ListViewArticles_GetData([ViewState("OrderBy")]String OrderBy = null)
        {
            var articles = this.Data.Articles.AsQueryable();
            if (OrderBy != null)
            {
                articles = this.SortArticles(articles, OrderBy, this.sortDirection);
            }
            return articles;
        }

        public void ListViewArticles_UpdateItem(int id)
        {
            var article = this.Data.Articles.Find(id);

            if (article == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(article);
            if (ModelState.IsValid)
            {
                this.Data.SaveChanges();
            }
        }

        public void ListViewArticles_DeleteItem(int id)
        {
            var article = this.Data.Articles.Find(id);

            if (article == null)
            {
                return;
            }

            this.Data.Articles.Remove(article);
            this.Data.SaveChanges();
        }

        public IQueryable<Category> EditArticleCategory_GetData()
        {
            return this.Data.Categories;
        }

        protected void CreateNewArticle_Click(object sender, EventArgs e)
        {
            this.Validate();
            if (IsValid)
            {
                this.Data.Articles.Add(new Article()
                {
                    UserId = this.User.Identity.GetUserId(),
                    Title = this.NewArticleTitle.Text,
                    CategoryId = int.Parse(this.NewArticleCategory.SelectedValue),
                    Content = this.NewArticleContent.Text,
                    DateCreated = DateTime.Now
                });

                this.Data.SaveChanges();

                this.InsertNewArticleBtn.Visible = true;
                this.CreateArticleHolder.Visible = false;

                Response.Redirect(Request.Url.ToString());
            }
        }

        protected void CancelNewArticle_Click(object sender, EventArgs e)
        {
            this.InsertNewArticleBtn.Visible = true;
            this.CreateArticleHolder.Visible = false;
        }

        protected void InsertNewArticleBtn_Click(object sender, EventArgs e)
        {
            this.InsertNewArticleBtn.Visible = false;
            this.CreateArticleHolder.Visible = true;
        }

        protected void ListViewArticles_Sorting(object sender, ListViewSortEventArgs e)
        {
            e.Cancel = true;
            ViewState["OrderBy"] = e.SortExpression;
            this.ListViewArticles.DataBind();
        }

        public SortDirection sortDirection
        {
            get
            {
                if (ViewState["sortdirection"] == null)
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
                else if ((SortDirection)ViewState["sortdirection"] == SortDirection.Ascending)
                {
                    ViewState["sortdirection"] = SortDirection.Descending;
                    return SortDirection.Descending;
                }
                else
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
            }
            set
            {
                ViewState["sortdirection"] = value;
            }
        }

        private IQueryable<Article> SortArticles(IQueryable<Article> articles, string orderBy, SortDirection direction)
        {
            switch (orderBy)
            {
                case "Title": return direction == SortDirection.Descending ? articles.OrderByDescending(a => a.Title) : articles.OrderBy(a => a.Title);
                case "DateCreated": return direction == SortDirection.Descending ? articles.OrderByDescending(a => a.DateCreated) : articles.OrderBy(a => a.DateCreated);
                case "Category": return direction == SortDirection.Descending ? articles.OrderByDescending(a => a.Category.Name) : articles.OrderBy(a => a.Category.Name);
                case "Likes": return direction == SortDirection.Descending ? articles.OrderByDescending(a => a.Likes.Count()) : articles.OrderBy(a => a.Likes.Count());
                default: return articles;
            }
        }
    }
}