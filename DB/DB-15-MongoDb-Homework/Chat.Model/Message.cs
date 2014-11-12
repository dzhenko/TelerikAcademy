namespace Chat.Model
{
    using System;

    using MongoDB.Bson;

    public class Message
    {
        public ObjectId Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public User User { get; set; }
    }
}
