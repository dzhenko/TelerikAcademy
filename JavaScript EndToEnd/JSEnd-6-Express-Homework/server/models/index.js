'use strict';

var userModel = require('../models/User'),
    messageModel = require('../models/Message'),
    reportModel = require('../models/Report'),
    gameObjectsModel = require('../models/GameObjects');

module.exports = {
    user: userModel,
    gameObjects: gameObjectsModel,
    message: messageModel,
    report: reportModel
};