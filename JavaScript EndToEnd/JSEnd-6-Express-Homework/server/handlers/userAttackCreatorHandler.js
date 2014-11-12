'use strict';

var game = require('../game/index'),
    distance = require('../utilities/distance');

function isPossibleToAttack(objects, ships) {
    for (var i = 0; i < ships.length; i++) {
        if (objects.ships[i] < ships[i]) {
            return false;
        }
    }

    return true;
}

// sync call
module.exports = {
    createAttack: function (objects, targetObjects, ships, turns) {
        if (!isPossibleToAttack(objects, ships)) {
            return false;
        }

        if (turns < 4) {
            turns = 4;
        }
        else if (turns > 14) {
            turns = 14
        }

        var timeToFly = distance.millisecondsBetweenCoords(objects.coordinates, targetObjects.coordinates)
            * (2 - game.upgrades[objects.upgrades[6]]);
        var timeToHit = timeToFly + (new Date()).getTime();
        var newShips = [0,0,0,0];

        for (var i = 0; i < ships.length; i++) {
            // removing ships from attacker
            newShips[i] = objects.ships[i] - ships[i];

        }

        objects.ships = newShips;

        targetObjects.defences.push({
            sourceID: targetObjects.owner,
            source: objects.coordinates,
            time: timeToHit
        });
        // async - doesn't matter
        targetObjects.save();

        objects.attacks.push({
            target: targetObjects.owner,
            time: timeToHit,
            ships: ships,
            turns: turns
        });

        return true;
    }
};
