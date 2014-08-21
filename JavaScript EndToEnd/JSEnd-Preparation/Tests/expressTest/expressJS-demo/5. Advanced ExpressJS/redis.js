var express = require('express');

var app = express();

var RedisStore = require('connect-redis')(express);

app.configure( function () {
    app.use(express.cookieParser());
    app.use(express.session({ store: new RedisStore, secret: 'Passphrase to encrpyt session'}));
});


app.get('/', function (req, res) {
    console.log(req.sessionID);
    req.session.name = req.session.name || new Date().toUTCString();
    res.send(req.session.name);
});

app.listen(3000);