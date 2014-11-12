'use strict';

var userInitialObjects = require('../game/initialUserObjects'),
    buildingsModel = require('../game/buildingsModel'),
    troopsModel = require('../game/troopsModel'),
    shipsModel = require('../game/shipsModel'),
    upgradesModel = require('../game/upgradesModel'),
    upgradesCostModel = require('../game/upgradesCostModel');

module.exports = {
    initialObjects: userInitialObjects,
    buildings: buildingsModel,
    troops: troopsModel,
    ships: shipsModel,
    upgrades: upgradesModel,
    upgradesCost: upgradesCostModel
};