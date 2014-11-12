namespace NewsSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NewsSystem.Models;

    public partial class News : BasePage
    {
        public IEnumerable<Article> ListViewMostBooks_GetData()
        {
            return this.Data.Articles.OrderByDescending(a => a.Likes.Count(l => l.Value == true)).Take(3);
        }

        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.Data.Categories.OrderBy(c => c.Name);
        }
    }
}