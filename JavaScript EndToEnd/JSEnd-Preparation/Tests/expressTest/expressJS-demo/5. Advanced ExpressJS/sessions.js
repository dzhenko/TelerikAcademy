var express = require('express');

var app = express();

app.configure( function () {
    app.use(express.cookieParser());
    app.use(express.session({ secret: 'Passphrase to encrpyt session'}));
});


app.get('/', function (req, res) {
    console.log(req.sessionID);
    req.session.name = req.session.name || new Date().toUTCString();
    res.send(req.session.name);
});

app.listen(3000);