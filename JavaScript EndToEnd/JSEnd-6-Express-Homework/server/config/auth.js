'use strict';

var passport = require('passport');

module.exports = {
    login: function(req, res, next) {
        var auth = passport.authenticate('local', function(err, user) {
            if (err) {
                return next(err);
            }

            if (!user) {
                res.send({success: false});
            }

            req.logIn(user, function(err){
                if (err) {
                    return next(err);
                }

                res.send({success: true, user: user});
            });
        });

        auth(req, res, next);
    },
    logout: function(req, res, next) {
        req.logout();
        res.end();
    },
    isAuthenticated: function(req, res, next) {
        if (!req.isAuthenticated()) {
            res.render('index');
            res.status(403);
            res.end();
        }
        else if (req.params && req.params.owner && req.user._id != req.params.owner) {
            res.render('index');
            res.status(403);
            res.end();
        }
        else {
            next();
        }
    },
    isInRole: function(role) {
        return function(req, res, next) {
            if (req.isAuthenticated() && req.user.roles.indexOf(role) >= 0) {
                next();
            }
            else {
                res.status(403);
                res.end();
            }
        }
    }
};