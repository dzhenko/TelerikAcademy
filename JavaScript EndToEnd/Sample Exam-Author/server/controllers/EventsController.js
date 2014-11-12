var events = require('../data/events'),
    systemConstants = require('../config/systemConstants'),
    errorLogger = require('../utilities/errorLogger');

var CONTROLLER_NAME = 'events';

function validateEventData(eventData) {
    var success = true;
    var reason;

    if (!eventData.title) {
        success = false;
        reason = 'Event must have a title';
    }

    if (!eventData.description) {
        success = false;
        reason = 'Event must have a description';
    }

    if (new Date(eventData.date) < new Date()) {
        success = false;
        reason = 'Event must be in the future';
    }

    if (systemConstants.eventCategories.indexOf(eventData.category) < 0) {
        success = false;
        reason = 'Invalid event category';
    }

    return {
        success: success,
        reason: reason
    }
}

function validateJoinEvent(user, event) {
    var success = true;
    var reason;

    if (event.participants.indexOf(user.username) >= 0) {
        reason = 'You are already a part of this event';
        success = false;
    }

    if (event.date <= new Date()) {
        reason = 'This event is in the past';
        success = false;
    }

    var haveInitiative = false;
    for (var i = 0; i < event.type.initiatives.length; i++) {
        if (user.initiatives.indexOf(event.type.initiatives[i]) >= 0) {
            haveInitiative = true;
            break;
        }
    }
    if (!haveInitiative) {
        reason = 'You do not have the initiative for this event';
        success = false;
    }

    var haveSeason = false;
    for (var i = 0; i < event.type.seasons.length; i++) {
        if (user.seasons.indexOf(event.type.seasons[i]) >= 0) {
            haveSeason = true;
            break;
        }
    }
    if (!haveSeason) {
        success = false;
        reason = 'You do not have the season for this event';
    }

    return {
        success: success,
        reason: reason
    }
}

module.exports = {
    getListEvents: function(req, res, next) {
        events.getSuitableForUserEvents(req.params.category, req.user, req.query.page , function(err, events) {
            res.render(CONTROLLER_NAME + '/list', {
                events : events
            })
        })
    },
    createComment: function(req, res, next) {
        events.getById(req.body.id, function(err, event) {
            if (err) {
                req.session.error = 'Could not find event with such id';
                res.redirect('/');
                return;
            }

            if (event.participants.indexOf(req.user.username) < 0) {
                req.session.error = 'You can only comment events that you are a part of!';
                res.redirect('/');
                return;
            }

            events.comment(req.body.id, req.body.comment, function(err, comment) {
                if (err) {
                    errorLogger('could not add comment' + err);
                    req.session.error = 'Could not add comment';
                    res.redirect('/');
                    return;
                }

                res.redirect('/event/' + req.body.id);
            });
        });
    },
    joinEvent: function(req, res, next) {
        events.getById(req.params.id, function(err, event) {
            if (err) {
                req.session.error = 'Could not find event with such id';
                res.redirect('/');
                return;
            }

            var validJoinConditions = validateJoinEvent(req.user, event);
            if (!validJoinConditions.success) {
                req.session.error = validJoinConditions.reason;
                res.redirect('/');
                return;
            }

            events.join(req.user, event, function(err) {
                if (err) {
                    errorLogger(err);
                    return;
                }

                res.redirect('/event/' + event._id);
            });
        })
    },
    leaveEvent: function(req, res, next) {
        events.getById(req.params.id, function(err, event) {
            if (err) {
                req.session.error = 'Could not find event with such id';
                res.redirect('/');
                return;
            }

            if (!event.participants.indexOf(req.user.username < 0)) {
                req.session.error = "You are not a part of this event";
                res.redirect('/');
                return;
            }

            events.leave(req.user, event, function(err) {
                if (err) {
                    errorLogger(err);
                    return;
                }

                res.redirect('/event/' + event._id);
            });

        })
    },
    getEventDetails: function(req, res, next) {
        events.getById(req.params.id, function(err, event) {
            if (err) {
                req.session.error = 'Could not find event with such id';
                res.redirect('/');
                return;
            }

            var canJoin = req.user.username !== event.creatorName && event.participants.indexOf(req.user.username) < 0;
            var canLeave = event.participants.indexOf(req.user.username) >= 0;
            var canComment = canLeave || req.user.username === event.creatorName;

            res.render(CONTROLLER_NAME + '/details', {
                event : event,
                canJoin: canJoin,
                canLeave: canLeave,
                canComment: canComment
            });
        })
    },
    getCreateEvent: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/create', {
            initiatives : systemConstants.initiativesTypes,
            seasons: systemConstants.seasonsTypes,
            categories: systemConstants.eventCategories
        });
    },
    postCreateEvent: function(req, res, next) {
        if (!req.user.phone) {
            req.session.error = 'Users without phone can not create events';
            res.redirect('/');
            return;
        }

        var validEventData = validateEventData(req.body);
        if(!validEventData.success) {
            req.session.error = validEventData.reason;
            res.redirect('/create-event');
            return;
        }

        var event = {};
        if (req.body.eventType === 'public') {
            event.type = {
                initiatives: systemConstants.initiativesTypes,
                seasons: systemConstants.seasonsTypes
            }
        }
        else if (req.body.eventType === 'initiative') {
            event.type = {
                initiatives: [req.body.initiative],
                seasons: systemConstants.seasonsTypes
            }
        }
        else {
            event.type = {
                initiatives: [req.body.initiative],
                seasons: [req.body.season]
            }
        }

        event.title = req.body.title;
        event.description = req.body.description;

        event.location = {
            latitude: req.body.latitude,
            longitude: req.body.longitude
        };

        event.category = req.body.category;
        event.date = new Date(req.body.date);

        event.creatorName = req.user.username;
        event.creatorPhone = req.user.phone;
        event.participants = [req.user.username];

        events.create(event, function(err, newEvent) {
            if (err) {
                errorLogger('Could not save event ' + err);
                req.session.error = err;
                res.redirect('/create-event');
                return;
            }

            res.redirect('/event/' + newEvent._id);
        })
    }
};