namespace LibrarySystem
{
    using System;
    using System.Linq;

    using LibrarySystem.Models;

    public partial class Books : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.Data.Categories;
        }
    }
}