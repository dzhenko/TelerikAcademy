namespace Chat.Model
{
    using MongoDB.Bson;

    public class User
    {
        public ObjectId Id { get; set; }

        public string Username { get; set; }
    }
}
