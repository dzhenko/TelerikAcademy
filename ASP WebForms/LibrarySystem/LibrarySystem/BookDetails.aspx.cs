using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class BookDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public LibrarySystem.Models.Book FormViewBook_GetItem([QueryString("id")]int? bookId)
        {
            if (bookId == null)
            {
                Response.Redirect("~/");
            }

            return this.Data.Books.Find(bookId);
        }
    }
}