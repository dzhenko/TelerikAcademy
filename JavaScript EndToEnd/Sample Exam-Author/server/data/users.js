var User = require('mongoose').model('User'),
    errorLogger = require('../utilities/errorLogger');

module.exports = {
    create: function(user, callback) {
        User.create(user, callback);
    },
    addPoints: function(username, points) {
                                                   //increases the points by the given amount
        User.findOneAndUpdate({username:username},{ $inc: { points: points }}, function(err) {
            if (err) {
                errorLogger('Error saving user after adding points ' + err);
            }
        })
    },
    update: function(username, user, callback) {
        User.findOneAndUpdate({username: username}, user, callback);
    }
};