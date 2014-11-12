'use strict';

var mongoose = require('mongoose'),
    Message = mongoose.model('Message');

module.exports = {
    getAll : function(req, res, next) {
        Message.find({owner: req.user._id}).exec(function(err, userMessages) {
            if (err) {
                console.log('Game messages could not be loaded ' + err);
                return;
            }

            if (!userMessages) {
                console.log('Un-existing user required his messages');
                res.status(404);
                res.end();
                return;
            }

            var allMessages = userMessages;

            Message.find({owner: req.user._id}).remove().exec(function(err) {
                if (err) {
                    console.log('Game messages could not be deleted ' + err);
                    return;
                }
                res.send({
                    allMessages : allMessages,
                    success : true
                });
            });
        });
    },
    createMessage: function(req, res, next) {
        var message = {
            fromID: req.user._id,
            from : req.user.username,
            owner: req.body.targetID,
            text: req.body.textToSend
        };

        Message.create(message, function(err, message){
            if (err) {
                console.log('Game message could not be created ' + err);
                return;
            }

            res.send({
                message : message,
                success : true
            });
        });
    }
};