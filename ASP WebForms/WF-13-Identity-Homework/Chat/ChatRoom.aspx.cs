using System;
using System.Collections.Generic;
using System.Linq;
using Chat.Models;

namespace Chat
{
    public partial class ChatRoom : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new ApplicationDbContext();
        }

        protected void SendMsgBtn_Click(object sender, EventArgs e)
        {
            this.db.Messages.Add(new Message()
            {
                Text = string.IsNullOrEmpty(this.ChatMsg.Text) ? "Empty" : this.ChatMsg.Text
            });

            this.db.SaveChanges();

            this.DataBind();
        }

        public IEnumerable<Message> Messages_GetAll()
        {
            return this.db.Messages.OrderByDescending(m => m.Id);
        }
    }
}