// NODE_ENV=production node index.js

var express = require('express'),
    path = require('path');

var app = express();

app.configure('production', function () {
    app.set('title', 'Production App');
    app.use(express.favicon());
    app.use(app.router);
});

app.configure('development', function () {
    app.set('title', 'Development App');
    app.use(express.logger('dev'));
    app.use(app.router);
});

app.get('/', function (req, res) {
    res.send('Running under title ' + app.get('title'));
});

app.listen(3000);
