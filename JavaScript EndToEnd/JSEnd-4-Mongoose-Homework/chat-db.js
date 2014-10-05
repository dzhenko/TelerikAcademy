'use strict';

var mongoose = require('mongoose'),
    Schema = mongoose.Schema;

mongoose.connect('mongodb://localhost/chatDb');

var db = mongoose.connection;

db.once('open', function (err) {
    if (err) {
        console.log('Database could not be opened' + err);
    }

    console.log('Database up and running');
});

db.on('error', function (err) {
    console.log('Database error ' + err);
});

var userSchema = Schema({
    user: { type: String, require: '{PATH} is required', unique: true },
    pass: String,
    messages: [{ type: Schema.Types.ObjectId, ref: 'Message' }]
});

var messageSchema = Schema({
    from: { type: Schema.Types.ObjectId, ref: 'User' },
    to: { type: Schema.Types.ObjectId, ref: 'User' },
    time: { type: Date, default: new Date() },
    text: String
});

var User = mongoose.model('User', userSchema);
var Message = mongoose.model('Message', messageSchema);

function errorHandler(err) {
    if (err) console.log(err);
}

function registerUser(user) {
    User.create(user, errorHandler);
}

function sendMessage(message) {
    User.findOne({user: message.from}, function (err, userFrom) {
        if (err) {
            errorHandler('Could not find from user: ' + err);
            return;
        }

        User.findOne({user: message.to}, function (err, userTo) {
            if (err) {
                errorHandler('Could not find from to: ' + err);
                return;
            }

            var newMessage = {
                from: userFrom,
                to: userTo,
                text: message.text
            };

            Message.create(newMessage, function(err, createdMessage) {
                if (err) {
                    errorHandler(err);
                    return;
                }

                userFrom.messages.push(createdMessage);
                userTo.messages.push(createdMessage);

                userFrom.save(errorHandler);
                userTo.save(errorHandler);
            });
        });
    });
}

function getMessages(withAnd, cb) {
    User.findOne({user: withAnd.with}, function (err, userFrom) {
        if (err) {
            errorHandler('Could not find user with : ' + err);
            return;
        }

        User.findOne({user: withAnd.and}, function (err, userTo) {
            if (err) {
                errorHandler('Could not find user and: ' + err);
                return;
            }

            Message.find({}).or([
                { from: userFrom._id, to: userTo._id},
                { from: userTo._id, to: userFrom._id}
            ]).exec(function (err, messages) {
                if (err) {
                    errorHandler('Could not find messages : ' + err);
                    return;
                }

                if (cb) {
                    cb(messages);
                }
            });
        })
    })
}

module.exports = {
    registerUser: registerUser,
    sendMessage: sendMessage,
    getMessages: getMessages
};