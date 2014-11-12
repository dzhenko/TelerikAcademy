var users = require('../data/users'),
    events = require('../data/events'),
    errorLogger = require('../utilities/errorLogger'),
    profilePictures = require('../utilities/profilePictures');

var CONTROLLER_NAME = 'profile';

module.exports = {
    getProfile: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/profile', {
            profilePictureLink : profilePictures.getPathToUserPicture(req.user.username)
        })
    },
    postProfile : function(req, res, next) {
        req.pipe(req.busboy);

        var newUserData = {};

        req.busboy.on('file', function (fieldname, file, filename) {
            if (!filename) {
                profilePictures.handleNoUserPicture(file, filename);
            }
            else {
                var fileType = filename.substring(filename.lastIndexOf('.') + 1);

                if (fileType === 'jpg') {
                    profilePictures.saveUserPicture(file, req.user.username);
                }
                else {
                    req.session.error = 'Unacceptable profile image file type - only JPG accepted!';
                    res.redirect('/profile');
                }
            }
        });

        req.busboy.on('field', function(fieldname, val) {
            newUserData[fieldname] = val;
        });

        req.busboy.on('finish', function() {
            users.update(req.user.username, newUserData, function(err, user) {
                if (err) {
                    req.session.error = 'Could not update user';
                    errorLogger('Failed to register new user: ' + err);

                }

                res.redirect('/profile');
            });
        });
    },
    getCreatedEvents: function(req, res, next) {
        events.getCreatedByUser(req.user.username, function(err, events) {
            if (err) {
                errorLogger('Could not get created by user events');
                return;
            }

            res.render(CONTROLLER_NAME + '/list-specific-events', {
                events : events,
                title: 'Created events'
            })
        })
    },
    getJoinedEvents: function(req, res, next) {
        events.getJoinedByUser(req.user.username, function(err, events) {
            if (err) {
                errorLogger('Could not get created by user events');
                return;
            }

            res.render(CONTROLLER_NAME + '/list-specific-events', {
                events : events,
                title: 'Joined events'
            })
        })
    },
    getPastEvents: function(req, res, next) {
        events.getPassedEvents(req.user.username, function(err, events) {
            if (err) {
                errorLogger('Could not get created by user events');
                return;
            }

            res.render(CONTROLLER_NAME + '/list-specific-events', {
                events : events,
                title: 'Joined events'
            })
        })
    },
};