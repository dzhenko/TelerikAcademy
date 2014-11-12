using Chat.Models;
using System;
using System.Linq;
using System.Web.UI;

namespace Chat
{
    public partial class About : Page
    {
        private ApplicationDbContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new ApplicationDbContext();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Message> ListView_GetData()
        {
            return this.db.Messages.OrderByDescending(m => m.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListView_UpdateItem(int? id)
        {
            var message = this.db.Messages.Find(id);
            if (message == null)
            {
                ModelState.AddModelError(String.Empty, String.Format("An message with ID {0} could not be found.", id));
                return;
            }
            TryUpdateModel(message);
            if (ModelState.IsValid)
            {
                this.db.SaveChanges();
            }
        }
    }
}