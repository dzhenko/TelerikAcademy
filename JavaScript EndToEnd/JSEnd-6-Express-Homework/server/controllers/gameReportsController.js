'use strict';

var Report = require('mongoose').model('Report');

module.exports = {
    getAll : function(req, res, next) {
        Report.find({owner: req.user._id}).exec(function(err, userReports) {
            if (err) {
                console.log('Game reports could not be loaded ' + err);
                return;
            }

            if (!userReports) {
                console.log('Un-existing user required his game reports');
                res.status(404);
                res.end();
                return;
            }

            var allReports = userReports;

            Report.find({owner: req.user._id}).remove().exec(function(err) {
                if (err) {
                    console.log('Game reports could not be deleted ' + err);
                    return;
                }
                res.send({
                    allReports : allReports,
                    success : true
                });
            });
        });
    }
};