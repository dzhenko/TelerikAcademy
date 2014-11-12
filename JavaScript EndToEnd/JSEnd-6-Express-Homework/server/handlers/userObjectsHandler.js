'use strict';

var GameObjects = require('mongoose').model('GameObjects'),
    game = require('../game/index'),
    attackHandler = require('../handlers/attacksHandler');

module.exports = {
    // sync call
    refreshUserGameObjects: function (objects) {
        var now = (new Date()).getTime();
        var diffMs = now - objects.updated;

//        // in case spam bot requires resources updates too often
//        if (diffMs < 60000) {
//            return;
//        }

        // updating
        objects.updated = now;

        // resources
        objects.minerals += Math.round(
                ((diffMs / 60000) * game.buildings.mineralFactory.amount[objects.buildings[0]]) *
                (game.upgrades[objects.upgrades[0]])
        );
        objects.gas += Math.round(
                ((diffMs / 60000) * game.buildings.gasFactory.amount[objects.buildings[1]]) *
                (game.upgrades[objects.upgrades[1]])
        );

        var i;
        // tasks
        // reverse iteration to prevent splice reordering of indexes
        for (i = objects.tasks.length - 1; i >= 0; i--) {
            var task = objects.tasks[i];

            if (task.time <= now) {
                var newObjects = objects[task.type].slice();
                newObjects[task.indexToAddTo]++;
                objects[task.type] = newObjects;

                // removing the task
                objects.tasks.splice(i, 1);
            }
        }

        // defences - remove warnings if they have happened
        for (i = objects.defences.length - 1; i >= 0; i--) {
            if (objects.defences[i].time <= now) {
                // async - doesnt matter
                GameObjects.findOne({owner: objects.defences[i].sourceID}).exec(function(err, defenderGameObjects) {
                    if (err) {
                        console.log('Game objects could not be loaded ' + err);
                    }

                    if (!userGameObjects) {
                        console.log('Un-existing user required his game objects');
                        res.status(404);
                        res.end();
                    }

                    // sync call
                    userObjectsHandler.refreshUserGameObjects(defenderGameObjects);
                });

                objects.defences.splice(i, 1);
            }
        }

        // comebacks - attackers are home
        for (i = objects.comebacks.length - 1; i >= 0; i--) {
            var comeback = objects.comebacks[i];

            if (comeback.time <= now) {
                // resources
                objects.minerals += comeback.cargo[0];
                objects.gas += comeback.cargo[1];

                var newShips = objects.ships.slice();

                // ships back to bay
                for (var s = 0; s < comeback.ships.length; s++) {
                    newShips[s] += comeback.ships[s];
                }

                objects.ships = newShips;

                // removing the task
                objects.comebacks.splice(i, 1);
            }
        }

        // attacks - pass to attack handler and remove from array
        for (i = objects.attacks.length - 1; i >= 0; i--) {
            if (objects.attacks[i].time <= now) {
                var ships = objects.attacks[i].ships;

                // call async func and remove from array
                attackHandler.handleAttackForTargetId({
                        attackerObjectsID: objects._id,
                        sourceCoords: objects.coordinates,
                        source: objects.owner,
                        ships: [ships[0], ships[1], ships[2], ships[3]],
                        airUpgrades: [objects.upgrades[7], objects.upgrades[8], objects.upgrades[9]]
                    },
                    objects.attacks[i].target,
                    objects.attacks[i].turns,
                    objects.attacks[i].time - objects.attacks[i].created);

                objects.attacks.splice(i, 1);
            }
        }
    }
};