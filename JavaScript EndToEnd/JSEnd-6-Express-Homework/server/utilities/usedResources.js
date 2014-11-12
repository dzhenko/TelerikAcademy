'use strict';

var game = require('../game/');

module.exports = {
    usedEnergy: function (objects) {
        var energy = 0;
        var indexes = objects.buildings;

        energy += game.buildings.mineralFactory.energy[indexes[0]];
        energy += game.buildings.gasFactory.energy[indexes[1]];
        // energy += game.buildings.solarPanels.energy[indexes[2]]; - cost is always 0
        energy += game.buildings.supply.energy[indexes[3]];
        energy += game.buildings.troops.energy[indexes[4]];
        energy += game.buildings.ships.energy[indexes[5]];
        energy += game.buildings.upgrades.energy[indexes[6]];

        return energy;
    },
    usedSupply: function (objects) {
        var supply = 0;
        var troopsIndexes = objects.troops;
        var shipsIndexes = objects.ships;

        supply += game.troops.supply[0] * troopsIndexes[0];
        supply += game.troops.supply[1] * troopsIndexes[1];
        supply += game.troops.supply[2] * troopsIndexes[2];

        supply += game.ships.supply[0] * shipsIndexes[0];
        supply += game.ships.supply[1] * shipsIndexes[1];
        supply += game.ships.supply[2] * shipsIndexes[2];
        supply += game.ships.supply[3] * shipsIndexes[3];

        var i;
        // includes all the attacking ships
        for (i = 0; i < objects.attacks.length; i++) {
            var attackShips = objects.attacks[i].ships;

            supply += game.ships.supply[0] * attackShips[0];
            supply += game.ships.supply[1] * attackShips[1];
            supply += game.ships.supply[2] * attackShips[2];
            supply += game.ships.supply[3] * attackShips[3];
        }

        // includes all the returning ships
        for (i = 0; i < objects.comebacks.length; i++) {
            var returningShips = objects.comebacks[i].ships;

            supply += game.ships.supply[0] * returningShips[0];
            supply += game.ships.supply[1] * returningShips[1];
            supply += game.ships.supply[2] * returningShips[2];
            supply += game.ships.supply[3] * returningShips[3];
        }

        // includes all the ships and troops being built
        for (i = 0; i < objects.tasks.length; i++) {
            var task = objects.tasks[i];

            if (task.type == 'ships') {
                supply += game.ships.supply[task.indexToAddTo];
            }
            else if (task.type == 'troops') {
                supply += game.troops.supply[task.indexToAddTo];
            }
        }

        return supply;
    }
};