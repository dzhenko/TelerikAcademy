var Db = require('mongodb').Db,
    MongoClient = require('mongodb').MongoClient,
    Server = require('mongodb').Server;

var mongoClient = new MongoClient(new Server('localhost', 27017));

mongoClient.open(function (err, client) {
    if (err) {
        throw err;
    }

    // the database we would require - created if it doesn't exist
    var db = client.db('HelloMongoDb');

    // gets the collection or creates it (like file full of JSONs in the aforementioned database
    var collection = db.collection('Question');

    var obj = {
        responseSighn: 'Nice to see you simple user!'
    };

    insertIntoDb(collection, obj);

    showDB(collection);
});

function insertIntoDb(dbCollectionToUse, obj) {
    // inserts whatever :)
    dbCollectionToUse.insert(obj, function(err){
        if (err) {
            throw err;
        }

        console.log("---Insert successfull---" + JSON.stringify(obj));
    });
}

function showDB(dbCollectionToUse) {
    // gets the content - needs to be to array because of original returned value
    dbCollectionToUse.find().toArray(function(err, data) {
        if (err) {
            throw err;
        }

        console.log(data);
    });
}

