namespace NewsSystem.Admin
{
    using System;
    using System.Linq;

    using System.Web.UI.WebControls;

    using NewsSystem.Models;

    public partial class EditCategories : BasePage
    {
        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.Data.Categories.OrderBy(c => c.Name);
        }

        public void ListViewCategories_DeleteItem(int id)
        {
            var category = this.Data.Categories.Find(id);
            if (category == null)
            {
                return;
            }

            var articlesList = category.Articles.ToList();

            foreach (var article in articlesList)
            {
                var likesList = article.Likes.ToList();
                foreach (var like in likesList)
                {
                    this.Data.Likes.Remove(like);
                }

                this.Data.Articles.Remove(article);
            }

            this.Data.Categories.Remove(category);

            this.Data.SaveChanges();
        }

        public void ListViewCategories_UpdateItem(int id)
        {
            this.Validate("Edit");
            var category = this.Data.Categories.Find(id);
            if (category == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(category);
            if (ModelState.IsValid)
            {
                try
                {
                    this.Data.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        }

        public void ListViewCategories_InsertItem()
        {
            this.Validate("Insert");
            var category = new Category();

            TryUpdateModel(category);

            if (ModelState.IsValid)
            {
                this.Data.Categories.Add(category);

                try
                {
                    this.Data.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        }

        protected void CustomNameFieldInsertValidatorName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !this.Data.Categories.Any(c => c.Name == args.Value);
        }
    }
}