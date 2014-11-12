'use strict';

var encryption = require('../utilities/encryption'),
    scanCost = require('../utilities/scanCost'),
    mongoose = require('mongoose'),
    User = mongoose.model('User'),
    GameObjects = mongoose.model('GameObjects'),
    initialUserObjects = require('../game/initialUserObjects'),
    userObjectsHandler = require('../handlers/userObjectsHandler');

function getUnusedCoordinatesForUser(otherUsers) {
    var invalidCoords = true;

    while (invalidCoords) {
        invalidCoords = false;
        var randomCoords = [Math.floor(Math.random() * 1000), Math.floor(Math.random() * 1000), Math.floor(Math.random() * 1000)];

        for (var i = 0; i < otherUsers.length; i++) {
            if (otherUsers[i].coordinates[0] === randomCoords[0] &&
                otherUsers[i].coordinates[1] === randomCoords[1] &&
                otherUsers[i].coordinates[2] === randomCoords[2]) {
                randomCoords = [Math.floor(Math.random() * 1000), Math.floor(Math.random() * 1000), Math.floor(Math.random() * 1000)];
                invalidCoords = true;
                break;
            }
        }
    }

    return randomCoords;
}

module.exports = {
    createUser: function (req, res, next) {
        var newUserData = req.body;
        newUserData.salt = encryption.generateSalt();
        newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
        newUserData.roles = []; // no roles for now

        User.find({}).exec(function(err, allUsers) {
            if (err) {
                console.log('Failed to find all users to get their coordinates' + err);
                return;
            }

            // sync call
            newUserData.coordinates = getUnusedCoordinatesForUser(allUsers);

            User.create(newUserData, function (err, user) {
                if (err) {
                    console.log('Failed to register new user ' + err);
                    res.status(400);
                    res.send(false);
                    return;
                }

                initialUserObjects.createDefaultsForUser(user);

                req.logIn(user, function (err) {
                    if (err) {
                        res.status(400);
                        return res.send({reason: err.toString()})
                    }

                    res.send(user);
                });
            })
        });
    },
    updateUser: function (req, res, next) {
        // double check
        if (req.user._id.toString() === req.body._id.toString() /*|| req.user.roles.indexOf('admin') >= 0*/) {
            var newUserData = {
                firstName : req.body.firstName,
                lastName: req.body.lastName
            };
            if (req.body.password && req.body.password.length > 5) {
                newUserData.salt = encryption.generateSalt();
                newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, req.body.password);
            }

            User.update({_id: newUserData._id}, newUserData, function () {
                res.end();
            });
        }
        else {
            req.send({reason: "You do not have permissions"});
        }
    },
    getAllUsers: function (req, res) {
        User.find({}).select('username coordinates _id').exec(function (err, collection) {
            if (err) {
                console.log('Users could not be loaded ' + err);
            }

            res.send(collection);
        });
    },
    // post with req.body.targetID
    scanUser: function(req, res) {
        GameObjects.findOne({owner: req.user._id}).exec(function(err, userGameObjects) {
            if (err) {
                console.log('Game objects could not be loaded ' + err);
                return;
            }

            if (!userGameObjects) {
                console.log('Un-existing user required his game objects');
                res.status(404);
                res.end();
                return;
            }

            // sync call
            var costOfScan = scanCost.calculate(userGameObjects);

            if (userGameObjects.minerals < costOfScan.minerals || userGameObjects.gas < costOfScan.gas) {
                res.send({
                    success: false
                });
                return;
            }

            userGameObjects.minerals = userGameObjects.minerals - costOfScan.minerals;
            userGameObjects.gas = userGameObjects.gas - costOfScan.gas;

            GameObjects.findOne({owner: req.params.target}).exec(function(err, targetObjects) {
                if (err) {
                    console.log('Game objects could not be loaded ' + err);
                    return;
                }

                // sync call
                userObjectsHandler.refreshUserGameObjects(userGameObjects);

                targetObjects.save(function(){
                    userGameObjects.save(function(){
                        res.send({
                            targetObjects : {
                                minerals: targetObjects.minerals,
                                gas: targetObjects.gas,
                                ships: targetObjects.ships,
                                troops: targetObjects.troops,
                                coordinates: targetObjects.coordinates,
                                owner: targetObjects.owner
                            },
                            success : true
                        });
                    });
                });
            });
        })
    }
};