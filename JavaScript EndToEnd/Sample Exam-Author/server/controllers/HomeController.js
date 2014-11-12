var stats = require('../utilities/stats'),
    errorLogger = require('../utilities/errorLogger');

module.exports = {
    getHome: function(req, res, next) {
        stats.get(function(err, events) {
            if (err) {
                errorLogger(err);
                return;
            }

            res.render('index', {
                events : events
            });
        })
    }
};