using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LibrarySystem.Admin
{
    public partial class EditBooks : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["lastSort"] == null)
            {
                ViewState["lastSort"] = string.Format("{0}#{1}")
            }
        }

        public void ListViewBooks_DeleteItem(int id)
        {
            // !!! Check for subitems
            Book book = this.Data.Books.Find(id);
            if (book == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.Data.Books.Remove(book);
            this.Data.SaveChanges();
        }

        public void ListViewBooks_UpdateItem(int id)
        {
            var book = this.Data.Books.Find(id);
            if (book == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(book);
            if (ModelState.IsValid)
            {
                this.Data.SaveChanges();
            }
        }

        protected void Sort_Command(object sender, CommandEventArgs e)
        {
            var sortBy = e.CommandArgument.ToString();
            var ascending = true;

            var lastSortObj = ViewState["lastSort"];

            if (lastSortObj != null && lastSortObj.ToString().StartsWith(sortBy))
            {
                ascending = !bool.Parse(lastSortObj.ToString().Substring(lastSortObj.ToString().IndexOf("#") + 1));
            }

            ViewState["lastSort"] = string.Format("{0}#{1}", sortBy, ascending);
        }

        private void GetListSorted(string param, bool ascending = true)
        {
            var books = this.Data.Books.AsQueryable();
            switch (param)
            {
                case "Title": books = ascending ? books.OrderBy(b => b.Title) : books.OrderByDescending(b => b.Title); break;
                case "Author": books = ascending ? books.OrderBy(b => b.Author) : books.OrderByDescending(b => b.Author); break;
                case "ISBN": books = ascending ? books.OrderBy(b => b.ISBN) : books.OrderByDescending(b => b.ISBN); break;
                case "WebSite": books = ascending ? books.OrderBy(b => b.WebSite) : books.OrderByDescending(b => b.WebSite); break;
                case "Category": books = ascending ? books.OrderBy(b => b.Category.Name) : books.OrderByDescending(b => b.Category.Name); break;
                default: return;
            }
            this.ListViewBooks.DataSource = books;
        }

        public IQueryable<Book> ListViewBooks_GetData()
        {
            var sortObj = ViewState["lastSort"].ToString();
            var param = sortObj.Substring(0, sortObj.IndexOf("#"));
            var ascending = bool.Parse(sortObj.Substring(sortObj.IndexOf("#") + 1));
            switch (param)
            {
                case "Title": return ascending ? this.Data.Books.OrderBy(b => b.Title) : this.Data.Books.OrderByDescending(b => b.Title); break;
                case "Author": return ascending ? this.Data.Books.OrderBy(b => b.Author) : this.Data.Books.OrderByDescending(b => b.Author); break;
                case "ISBN": return ascending ? this.Data.Books.OrderBy(b => b.ISBN) : this.Data.Books.OrderByDescending(b => b.ISBN); break;
                case "WebSite": return ascending ? this.Data.Books.OrderBy(b => b.WebSite) : this.Data.Books.OrderByDescending(b => b.WebSite); break;
                case "Category": return ascending ? this.Data.Books.OrderBy(b => b.Category.Name) : this.Data.Books.OrderByDescending(b => b.Category.Name); break;
                default: return this.Data.Books.OrderBy(b => b.Id);
            }
            return this.Data.Books.OrderBy(b => b.Id);
        }

        public IQueryable<Category> DDLCategory_GetData()
        {
            return this.Data.Categories.OrderBy(c => c.Id);
        }

        protected void ShowAdditionalTableHeaders(object sender = null, EventArgs e = null)
        {
            ((HtmlTableCell)(this.ListViewBooks.FindControl("DescrptionHiddenHeader"))).Visible = true;
        }

        protected void HideAdditionalTableHeaders(object sender = null, EventArgs e = null)
        {
            ((HtmlTableCell)(this.ListViewBooks.FindControl("DescrptionHiddenHeader"))).Visible = false;
        }

        protected void CreateNewBook_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.Data.Books.Add(new Book()
                {
                    Title = this.NewBookTitle.Text,
                    Author = this.NewBookAuthor.Text,
                    ISBN = this.NewBookISBN.Text,
                    WebSite = this.NewBookWebSite.Text,
                    CategoryId = int.Parse(this.NewBookCategory.SelectedValue),
                    Description = this.NewBookDescription.Text
                });

                this.Data.SaveChanges();

                this.DataBind();
            }
            else
            {

            }

            this.InsertNewBookBtn.Visible = true;
            this.CreateBookWell.Visible = false;
        }

        protected void CancelNewBook_Click(object sender, EventArgs e)
        {
            this.InsertNewBookBtn.Visible = true;
            this.CreateBookWell.Visible = false;
        }

        protected void InsertNewBookBtn_Click(object sender, EventArgs e)
        {
            this.InsertNewBookBtn.Visible = false;
            this.CreateBookWell.Visible = true;
        }
    }
}