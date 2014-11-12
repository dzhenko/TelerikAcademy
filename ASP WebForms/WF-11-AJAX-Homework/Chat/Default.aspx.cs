using Chat.Data;
using Chat.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MessageButton_Click(object sender, EventArgs e)
        {
            var db = new MessagesDbContext();
            db.Messages.Add(new Message()
                {
                    Date = DateTime.Now,
                    Text = this.MessageText.Text
                });
            db.SaveChanges();

            this.MessageText.Text = string.Empty;

            this.DataBind();
        }

        public IQueryable<Message> Messages_GetData()
        {
            return (new MessagesDbContext()).Messages.OrderByDescending(m => m.Date);
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            this.DataBind();
        }
    }
}