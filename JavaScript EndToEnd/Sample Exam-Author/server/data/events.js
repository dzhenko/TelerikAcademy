var Event = require('mongoose').model('Event');

var pageSize = 10;

function checkArrayCollisions(firstArr, secondArr) {
    for (var i = 0; i < firstArr.length; i++) {
        if (secondArr.indexOf(firstArr[i]) >= 0) {
            return true;
        }
    }

    return false;
}

module.exports = {
    create: function(event, callback) {
        Event.create(event, callback);
    },
    comment: function(id, comment, callback) {
        Event.findOneAndUpdate({_id: id},
            {$push: {comments: comment}},
            {safe: true, upsert: true},
            callback);
    },
    getPassed: function(cb) {
        Event.find({}, function(err, allEvents) {
            if (err) {
                cb(err);
                return;
            }

            var pastEvents = [];
            for (var i = 0; i < allEvents.length; i++) {
                if (allEvents[i].date < new Date()) {
                    pastEvents.push(allEvents[i]);
                }
            }

            cb(null, pastEvents);
        })
    },
    getById: function(id, callback) {
        Event.findOne({_id : id}, callback);
    },
    join: function(user, event, callback) {
        Event.findOneAndUpdate({_id: event._id},
            {$push: {participants: user.username}},
            {safe: true, upsert: true},
            callback);
    },
    leave: function(user, event, callback) {
        var newParticipants = [];

        for (var i = 0; i < event.participants.length; i++) {
            if (event.participants[i] !== user.username) {
                newParticipants.push(event.participants[i]);
            }
        }

        event.participants = newParticipants;

        event.save(callback);
    },
    getSuitableForUserEvents: function(category, user, page, callback) {
        Event.find({category: category}, function(err, allEvents) {
            if (err) {
                callback(err);
                return;
            }

            var suitableEvents = [];

            for (var i = 0; i < allEvents.length; i++) {
                if (allEvents[i].date < new Date()) {
                    continue;
                }

                if (allEvents[i].participants.indexOf(user.username) < 0 &&
                    checkArrayCollisions(user.initiatives, allEvents[i].type.initiatives) &&
                    checkArrayCollisions(user.seasons, allEvents[i].type.seasons)) {
                    suitableEvents.push(allEvents[i]);
                }
            }

            suitableEvents.sort(function(a, b) {
                return b.date - a.date;
            });

            if (page) {
                suitableEvents = suitableEvents.slice(parseInt(page) * pageSize, pageSize);
            }
            else {
                suitableEvents = suitableEvents.slice(0, pageSize);
            }

            if (callback) {
                callback(null, suitableEvents);
            }
        })
    },
    getCreatedByUser: function(username, cb) {
        Event.find({creatorName: username}, cb);
    },
    getJoinedByUser: function(username, cb) {
        Event.find({}, function(err, events) {
            if (err) {
                cb(err);
                return;
            }

            var joined = [];

            for (var i = 0; i < events.length; i++) {
                if (events[i].participants.indexOf(username) >= 0) {
                    joined.push(events[i]);
                }
            }

            cb(null, joined);
        })
    },
    getPassedEvents: function(username, cb) {
        Event.find({}, function(err, events) {
            if (err) {
                cb(err);
                return;
            }

            var joined = [];

            for (var i = 0; i < events.length; i++) {
                if (events[i].participants.indexOf(username) >= 0 && events[i].date < new Date()) {
                    joined.push(events[i]);
                }
            }

            cb(null, joined);
        })
    }
};