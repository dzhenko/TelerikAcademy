'use strict';

var GameObjects = require('mongoose').model('GameObjects'),
    userAttackCreatorHandler = require('../handlers/userAttackCreatorHandler'),
    attacksHandler = require('../handlers/attacksHandler');

module.exports = {
    // needs post with these three params req.params.targetID, req.params.ships, req.params.turns
    createAttack: function (req, res, next) {
        GameObjects.findOne({owner: req.user._id}).exec(function (err, userGameObjects) {
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

            GameObjects.findOne({owner: req.params.target}).exec(function (err, targetObjects) {
                if (err) {
                    console.log('Target objects could not be loaded ' + err);
                    return;
                }

                if (!targetObjects) {
                    console.log('Un-existing target required his game objects');
                    res.status(404);
                    res.end();
                    return;
                }

                // sync call
                var success = userAttackCreatorHandler.createAttack(userGameObjects, targetObjects, req.body.ships, req.body.turns);

                userGameObjects.save(function () {
                    res.send({
                        userGameObjects: userGameObjects,
                        success: success
                    });
                });
            })
        })
    },
    simulateAttack : function(req, res, next) {
        var report = attacksHandler.simulateAttack(req.body.attacker, req.body.defender, req.body.turns);
        res.send({
            report: report,
            success: true
        });
    }
};