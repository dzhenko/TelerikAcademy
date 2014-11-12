using System;
using System.Linq;
using System.Web.UI;
using Chat.Models;

namespace Chat
{
    public partial class Contact : Page
    {
        private ApplicationDbContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new ApplicationDbContext();
        }

        public void ListView_DeleteItem(int? id)
        {
            var message = this.db.Messages.Find(id);
            if (message == null)
            {
                return;
            }

            this.db.Messages.Remove(message);
            this.db.SaveChanges();
        }

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