'use strict';

var mongoose = require('mongoose'),
    modelsExports = require('../models');

module.exports = function (config) {
    mongoose.connect(config.db);
    var db = mongoose.connection;

    db.once('open', function (err) {
        if (err) {
            console.log('Database could not be opened' + err);
        }
    });

    db.on('error', function (err) {
        console.log('Database error ' + err);
    });
};

// For development
function clearDb() {
    modelsExports.user.removeAll();
    modelsExports.gameObjects.removeAll();
    modelsExports.message.removeAll();
    modelsExports.report.removeAll();
}

// For development
function showDb() {
    modelsExports.user.showAll();
    modelsExports.gameObjects.showAll();
    modelsExports.message.showAll();
    modelsExports.report.showAll();
}