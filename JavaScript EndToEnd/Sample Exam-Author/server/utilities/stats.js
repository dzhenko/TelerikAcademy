var events = require('../data/events');

var eventsObject;

module.exports = {
    get : function(callback) {                                          // 10 mins in miliseconds
        if (!eventsObject || eventsObject.updated > (new Date()).getTime() - 1000 * 60 * 10) {
            events.getPassed(function(err, events) {
                if (err) {
                    callback(err);
                    return;
                }

                eventsObject = {
                    events : events,
                    updated: (new Date()).getTime()
                };

                callback(null, eventsObject.events);
            })
        }
    }
};