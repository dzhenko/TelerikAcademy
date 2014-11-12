'use strict';

var game = require('../game/index'),
    usedResources = require('../utilities/usedResources');

function checkIfTaskCanBeStarted(objects, taskType) {
    // count current tasks
    var currentTasks = {
        buildings : 0,
        ships: 0,
        troops: 0,
        upgrades: 0
    };

    for (var i = 0; i < objects.tasks.length; i++) {
        var task = objects.tasks[i];
        currentTasks[task.type]++;
    }

    // only 1 building can be build at the same time
    if (taskType == 'buildings' && currentTasks.buildings == 1) {
        return false;
    }
    // level of troops barracks is not high enough to build more than X troops at the same time
    else if (taskType == 'troops' && currentTasks.troops >= game.buildings.troops.amount[objects.buildings[4]]) {
        return false;
    }
    // level of ship yard is not high enough to build more than X ships at the same time
    else if (taskType == 'ships' && currentTasks.ships >= game.buildings.ships.amount[objects.buildings[5]]) {
        return false;
    }
    // level of lab is not high enough to research more than X upgrades at the same time
    else if (taskType == 'upgrades' && currentTasks.upgrades >= game.buildings.upgrades.amount[objects.buildings[6]]) {
        return false;
    }

    // if here than it can be afforded.
    return true;
}

function calculateCost(objects, taskType, taskIndexToAddTo) {
    if (taskType == 'buildings') {
        var requestedBuilding;
        switch (taskIndexToAddTo) {
            case 0 : requestedBuilding = game.buildings.mineralFactory; break;
            case 1 : requestedBuilding = game.buildings.gasFactory; break;
            case 2 : requestedBuilding = game.buildings.solarPanels; break;
            case 3 : requestedBuilding = game.buildings.supply; break;
            case 4 : requestedBuilding = game.buildings.troops; break;
            case 5 : requestedBuilding = game.buildings.ships; break;
            case 6 : requestedBuilding = game.buildings.upgrades; break;
            // some kind of magic bug
            default : return false;
        }

        // check level now and afterwards
        var requestedLevelBuilding = objects.buildings[taskIndexToAddTo] + 1;

        // requested building is already at max level
        if (requestedLevelBuilding >= requestedBuilding.amount.length) {
            return false;
        }

        // energy calculation
        var usedEnergy = usedResources.usedEnergy(objects);
        var currentEnergy = game.buildings.solarPanels.amount[objects.buildings[2]];
        var remainingEnergy = currentEnergy - usedEnergy;
        var requiredEnergy = requestedBuilding.energy[requestedLevelBuilding] - requestedBuilding.energy[requestedLevelBuilding -1];
        if (remainingEnergy < requiredEnergy) {
            return false;
        }

        var buildingTimeCost = Math.round(requestedBuilding.time[requestedLevelBuilding] * (2 - game.upgrades[objects.upgrades[2]]));

        return {
            minerals: requestedBuilding.cost[requestedLevelBuilding],
            gas: 0,
            time: buildingTimeCost
        };

        //calculate
    }
    else if (taskType == 'upgrades') {
        var requestedLevelUpgrade = objects.upgrades[taskIndexToAddTo] + 1;

        // requested building is already at max level
        if (requestedLevelUpgrade >= game.upgrades.length) {
            return false;
        }

        var upgradeTimeCost = Math.round(game.upgradesCost.time[requestedLevelUpgrade] * (2 - game.upgrades[objects.upgrades[5]]));

        return {
            minerals: game.upgradesCost.minerals[requestedLevelUpgrade],
            gas: game.upgradesCost.gas[requestedLevelUpgrade],
            time: upgradeTimeCost
        }
    }
    else if (taskType == 'ships' || taskType == 'troops') {
        var usedSupply = usedResources.usedSupply(objects);
        var currentSupply = game.buildings.supply.amount[objects.buildings[3]];
        var remainingSupply = currentSupply - usedSupply;
        var requiredSupply = game[taskType].supply[taskIndexToAddTo];
        if (remainingSupply < requiredSupply) {
            return false;
        }

                               // 3 for air units speed 4 for ground unit construction speed;
        var timeUpgradeIndex = taskType == 'ships' ? 3 : 4;
        var unitTimeCost = Math.round(game[taskType].time[taskIndexToAddTo] * (2 - game.upgrades[objects.upgrades[timeUpgradeIndex]]));

        return {
            minerals: game[taskType].minerals[taskIndexToAddTo],
            gas: game[taskType].gas[taskIndexToAddTo],
            time: unitTimeCost
        }
    }
    else {
        // some kind of magic bug
        return false;
    }
}

function executeTask(objects, taskType, taskIndexToAddTo, cost) {
    if (objects.minerals >= cost.minerals && objects.gas >= cost.gas) {
        objects.minerals -= cost.minerals;
        objects.gas -= cost.gas;

        var now = (new Date()).getTime();
        var time = (cost.time * 60 * 1000) + now;

        objects.tasks.push({
            time: time,
            type: taskType,
            indexToAddTo: taskIndexToAddTo
        });

        return true;
    }

    return false;
}

// sync call
module.exports = {
    createTask: function (objects, taskType, taskIndexToAddTo) {
        var canBeStarted = checkIfTaskCanBeStarted(objects, taskType);
        if (!canBeStarted) {
            return false;
        }

        var cost = calculateCost(objects, taskType, taskIndexToAddTo);
        if (!cost) {
            return false;
        }

        return executeTask(objects, taskType, taskIndexToAddTo, cost);
    }
};