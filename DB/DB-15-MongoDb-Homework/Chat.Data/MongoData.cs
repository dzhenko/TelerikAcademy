namespace Chat.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Driver;

    using Chat.Model;
    using MongoDB.Driver.Builders;

    public class MongoData
    {
        private MongoDatabase db;

        public MongoData(bool useLocal)
        {
            this.InitializeDb(useLocal);
        }

        public void AddMessage(Message message)
        {
            this.db.GetCollection<Message>("messages").Insert(message);
        }

        public void AddMessage(string text, string username)
        {
            this.AddMessage(new Message() { Date = DateTime.Now, Text = text, User = new User() { Username = username } });
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return this.db.GetCollection<Message>("messages").FindAll();
        }

        public IEnumerable<Message> GetMessagesSinceDate(DateTime date)
        {
            var findNewMessagesQuery = Query.GT("Date", date);

            return this.db.GetCollection<Message>("messages").Find(findNewMessagesQuery);
        }

        private void InitializeDb(bool useLocal)
        {
            if (useLocal)
            {
                this.db = new MongoClient().GetServer().GetDatabase("chat");
            }
            else
            {
                this.db = new MongoClient("mongodb://admin:qwerty@ds033390.mongolab.com:33390/chat").GetServer().GetDatabase("chat");
            }
        }
    }
}
