namespace BattleNetShop.Data.MongoDb
{
    using System;
    using System.Collections.Generic;

    using MongoDB.Driver;

    internal class MongoDbHandler
    {
        private Lazy<MongoDatabase> database = new Lazy<MongoDatabase>(CreateConnection);

        public void ReadCollection<T>(string collectionName, Action<T> action)
        {
            var cursor = this.database.Value.GetCollection(collectionName).FindAllAs<T>();

            foreach (var category in cursor)
            {
                action(category);
            }
        }

        public void WriteCollection<T>(string collectionName, IEnumerable<T> collectionItems)
        {
            MongoCollection<T> collection = this.database.Value.GetCollection<T>(collectionName);

            foreach (var item in collectionItems)
            {
                collection.Insert(item);
            }
        }

        private static MongoDatabase CreateConnection() 
        {
            // Create server settings to pass connection string, timeout, etc.
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress(MongoDbSettings.Default.MongoDBAddress, MongoDbSettings.Default.MongoDBPort);

            // Create server object to communicate with our server
            MongoServer server = new MongoServer(settings);

            // Get our database instance to reach collections and data
            var database = server.GetDatabase(MongoDbSettings.Default.MongoDBName);

            return database;
        }
    }
}
