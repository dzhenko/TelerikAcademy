var users = require('../data/users'),
    encryption = require('../utilities/encryption'),
    systemConstants = require('../config/systemConstants'),
    errorLogger = require('../utilities/errorLogger'),
    profilePictures = require('../utilities/profilePictures');

var CONTROLLER_NAME = 'users';

function validateUserData(userData) {
    var validSymbols = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_ .';

    var success = true;
    var reason;

    if (userData.password != userData.confirmPassword) {
        reason = 'Passwords do not match!';
        success = false;

    }
    else if (userData.username.length < 6 || userData.username.length > 20) {
        reason = 'Username must be between 6 and 20 characters long!';
        success = false;
    }
    else {
        for (var i = 0; i < userData.username.length; i++) {
            if (validSymbols.indexOf(userData.username[i]) < 0) {
                reason = 'Username can only contain Latin letters, digits and the symbols "_" (underscore), " " (space) and "." (dot)!';
                success = false;
                break;
            }
        }
    }

    return {
        success : success,
        reason: reason
    }
}

module.exports = {
    getRegister: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/register', {
            initiatives : systemConstants.initiativesTypes,
            seasons: systemConstants.seasonsTypes,
            allowedImageTypes : systemConstants.allowedImageTypes
        })
    },
    postRegister: function(req, res, next) {
        var newUserData = {
            seasons: [],
            initiatives: []
        };

        req.pipe(req.busboy);

        req.busboy.on('file', function (fieldname, file, filename) {
            if (!filename) {
                profilePictures.handleNoUserPicture(file, filename);
            }
            else {
                var fileType = filename.substring(filename.lastIndexOf('.') + 1);

                if (fileType === 'jpg') {
                                                          // as the form first collects the username, this field will always be present
                    profilePictures.saveUserPicture(file, newUserData.username);
                }
                else {
                    req.session.error = 'Unacceptable profile image file type - only JPG accepted!';
                    res.redirect('/register');
                }
            }
        });

        req.busboy.on('field', function(fieldname, val) {
            if (fieldname === 'seasons') {
                newUserData.seasons.push(val);
            }
            else if (fieldname === 'initiatives') {
                newUserData.initiatives.push(val);
            }
            else {
                newUserData[fieldname] = val;
            }
        });

        req.busboy.on('finish', function() {
            var validUserData = validateUserData(newUserData);
            if (!validUserData.success) {
                req.session.error = validUserData.reason;
                res.redirect('/register');
                return;
            }

            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);

            users.create(newUserData, function(err, user) {
                if (err) {
                    req.session.error = 'Username already exists';
                    errorLogger('Failed to register new user: ' + err);
                    return;
                }

                req.logIn(user, function(err) {
                    if (err) {
                        // server side error - logging after creating user - users should not see this error
                        res.status(400);
                        errorLogger('Could not log in user!');
                        res.redirect('/login');
                    }
                    else {
                        res.redirect('/');
                    }
                })
            });
        });
    },
    getLogin: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    }
};