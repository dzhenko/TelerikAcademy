app.factory('Calculator', function (BuildingsModel, ShipsModel, TroopsModel, UpgradesModel) {
    'use strict';

    function flightTime(objects, coords) {
        var timePerClick = 18000000 / 1730;
        var takeOffMS = 17 * 60000;

        function get3DDistance(coord1, coord2) {
            return Math.sqrt(
                ((coord1[0] - coord2[0]) * (coord1[0] - coord2[0]) +
                    (coord1[1] - coord2[1]) * (coord1[1] - coord2[1]) +
                    (coord1[2] - coord2[2]) * (coord1[2] - coord2[2]))
            )
        }

        return Math.round(timePerClick * get3DDistance(objects.coordinates, coords) *
            (2 - UpgradesModel.multiplier[objects.upgrades[6]])) + takeOffMS;
    }

    function freeEnergy(objects) {
        var indexes = objects.buildings;
        var energy = BuildingsModel[2].amount[indexes[2]];

        for (var i = 0; i < BuildingsModel.length; i++) {
            energy -= BuildingsModel[i].energy[indexes[i]];
        }

        return energy;
    }

    function freeSupply(objects) {
        var supply = BuildingsModel[3].amount[objects.buildings[3]];
        var troopsIndexes = objects.troops;
        var shipsIndexes = objects.ships;

        supply -= TroopsModel.supply[0] * troopsIndexes[0];
        supply -= TroopsModel.supply[1] * troopsIndexes[1];
        supply -= TroopsModel.supply[2] * troopsIndexes[2];

        supply -= ShipsModel.supply[0] * shipsIndexes[0];
        supply -= ShipsModel.supply[1] * shipsIndexes[1];
        supply -= ShipsModel.supply[2] * shipsIndexes[2];
        supply -= ShipsModel.supply[3] * shipsIndexes[3];

        var i;
        // includes all the attacking ships
        for (i = 0; i < objects.attacks.length; i++) {
            var attackShips = objects.attacks[i].ships;

            supply -= ShipsModel.supply[0] * attackShips[0];
            supply -= ShipsModel.supply[1] * attackShips[1];
            supply -= ShipsModel.supply[2] * attackShips[2];
            supply -= ShipsModel.supply[3] * attackShips[3];
        }

        // includes all the returning ships
        for (i = 0; i < objects.comebacks.length; i++) {
            var returningShips = objects.comebacks[i].ships;

            supply -= ShipsModel.supply[0] * returningShips[0];
            supply -= ShipsModel.supply[1] * returningShips[1];
            supply -= ShipsModel.supply[2] * returningShips[2];
            supply -= ShipsModel.supply[3] * returningShips[3];
        }

        // includes all the ships and troops being built
        for (i = 0; i < objects.tasks.length; i++) {
            var task = objects.tasks[i];

            if (task.type == 'ships') {
                supply -= ShipsModel.supply[task.indexToAddTo];
            }
            else if (task.type == 'troops') {
                supply -= TroopsModel.supply[task.indexToAddTo];
            }
        }

        return supply;
    }

    function requiredResources(objects, type, index) {
        if (!objects) {
            return;
        }

        var cost = {
            time: requiredTime(objects, type, index)
        };

        switch (type) {
            case 'buildings' :
                cost.minerals = BuildingsModel[index].cost[objects.buildings[index] + 1];
                cost.energy = BuildingsModel[index].energy[objects.buildings[index] + 1] - BuildingsModel[index].energy[objects.buildings[index]];
                break;
            case 'ships' :
                cost.minerals = ShipsModel.minerals[index];
                cost.gas = ShipsModel.gas[index];
                cost.supply = ShipsModel.supply[index];
                break;
            case 'troops' :
                cost.minerals = TroopsModel.minerals[index];
                cost.gas = TroopsModel.gas[index];
                cost.supply = TroopsModel.supply[index];
                break;
            case 'upgrades' :
                cost.minerals = UpgradesModel.cost.minerals[objects.upgrades[index] + 1];
                cost.gas = UpgradesModel.cost.gas[objects.upgrades[index] + 1];
                break;
        }

        return cost;
    }

    function requiredResourcesMessage(objects, type, index) {
        var cost = requiredResources(objects, type, index);

        cost.time = convertToTime(cost.time);

        var message = ' will cost you';
        for (var resource in cost) {
            if (cost.hasOwnProperty(resource)) {
                message += ' ' + cost[resource] + ' ' + resource;
            }
        }

        return message;
    }

    function convertToTime(minutes) {
        return Math.floor(minutes / 60) + ' hours , ' + minutes % 60 + ' minutes';
    }

    function requiredTime(objects, type, index) {
        var time;
        switch (type) {
            case 'buildings' :
                time = BuildingsModel[index].time[objects.buildings[index] + 1] * (2 - UpgradesModel.multiplier[objects.upgrades[2]]);
                break;
            case 'ships' :
                time = ShipsModel.time[index] * (2 - UpgradesModel.multiplier[objects.upgrades[3]]);
                break;
            case 'troops' :
                time = TroopsModel.time[index] * (2 - UpgradesModel.multiplier[objects.upgrades[4]]);
                break;
            case 'upgrades' :
                time = UpgradesModel.cost.time[objects.upgrades[index] + 1] * (2 - UpgradesModel.multiplier[objects.upgrades[5]]);
                break;
        }

        return Math.round(time);
    }

    function canAffordBuilding(objects, index) {
        var cost = BuildingsModel[index].cost[objects.buildings[index] + 1];
        var energy = BuildingsModel[index].energy[objects.buildings[index] + 1] - BuildingsModel[index].energy[objects.buildings[index]];

        if (objects.minerals < cost) {
            return {
                answer: false,
                reason: 'Not enough minerals'
            }
        }
        else if (freeEnergy(objects) < energy) {
            return {
                answer: false,
                reason: 'Not enough energy'
            }
        }

        return {
            answer: true
        }
    }

    function canAffordShip(objects, index) {
        var minerals = ShipsModel.minerals[index];
        var gas = ShipsModel.gas[index];
        var supply = ShipsModel.supply[index];

        if (minerals > objects.minerals) {
            return {
                answer: false,
                reason: 'Not enough minerals'
            }
        }
        else if (gas > objects.gas) {
            return {
                answer: false,
                reason: 'Not enough gas'
            }
        }
        else if (supply > freeSupply(objects)) {
            return {
                answer: false,
                reason: 'Not enough supply'
            }
        }

        return {
            answer: true
        }
    }

    function canAffordTroop(objects, index) {
        var minerals = TroopsModel.minerals[index];
        var gas = TroopsModel.gas[index];
        var supply = TroopsModel.supply[index];

        if (minerals > objects.minerals) {
            return {
                answer: false,
                reason: 'Not enough minerals'
            }
        }
        else if (gas > objects.gas) {
            return {
                answer: false,
                reason: 'Not enough gas'
            }
        }
        else if (supply > freeSupply(objects)) {
            return {
                answer: false,
                reason: 'Not enough supply'
            }
        }

        return {
            answer: true
        }
    }

    function canAffordUpgrade(objects, index) {
        var minerals = UpgradesModel.cost.minerals[index];
        var gas = UpgradesModel.cost.gas[index];

        if (minerals > objects.minerals) {
            return {
                answer: false,
                reason: 'Not enough minerals'
            }
        }
        else if (gas > objects.gas) {
            return {
                answer: false,
                reason: 'Not enough gas'
            }
        }

        return {
            answer: true
        }
    }

    function upgradeInProgress(objects, index) {
        for (var i = 0; i < objects.tasks.length; i++) {
            if (objects.tasks[i].type == 'upgrades' && objects.tasks[i].indexToAddTo == index) {
                return false;
            }
        }

        return true;
    }

    function mineralsPerMinute(objects) {
        return Math.round(UpgradesModel.multiplier[objects.upgrades[0]] * BuildingsModel[0].amount[objects.buildings[0]]);
    }

    function gasPerMinute(objects) {
        return Math.round(UpgradesModel.multiplier[objects.upgrades[1]] * BuildingsModel[1].amount[objects.buildings[1]]);
    }

    return {
        freeEnergy: freeEnergy,
        freeSupply: freeSupply,
        flightTime: flightTime,
        requiredResources: requiredResources,
        requiredResourcesMessage: requiredResourcesMessage,
        convertToTime: convertToTime,
        requiredTime: requiredTime,
        canAffordBuilding: canAffordBuilding,
        canAffordShip: canAffordShip,
        canAffordTroop: canAffordTroop,
        canAffordUpgrade: canAffordUpgrade,
        upgradeInProgress: upgradeInProgress,
        mineralsPerMinute: mineralsPerMinute,
        gasPerMinute: gasPerMinute
    }
});