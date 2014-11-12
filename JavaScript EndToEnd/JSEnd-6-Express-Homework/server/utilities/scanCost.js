'use strict';

var game = require('../game/');

module.exports = {
    calculate: function(objects) {
        var mineralsCost = Math.round(game.buildings.mineralFactory.amount[objects.buildings[0]] * 15);
        var gasCost = Math.round(game.buildings.gasFactory.amount[objects.buildings[1]] * 15);

        return {
            minerals: mineralsCost,
            gas: gasCost
        }
    }
};