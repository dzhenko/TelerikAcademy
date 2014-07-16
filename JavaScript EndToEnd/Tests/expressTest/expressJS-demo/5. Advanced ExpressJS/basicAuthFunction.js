var express = require('express');


var app = express();

app.configure(function () {
    app.use(express.basicAuth( function (user, pass) {
        return user === pass;
    }));
});


app.get('/', function (req, res) {
    res.send('Accessed authorized section');
});


app.listen(3000);