app.controller('SimulateAttackCtrl', function ($scope, $rootScope, GameRequests, identity, RaceModel, TroopsModel, ShipsModel, UpgradesModel) {
    'use strict';

    $scope.raceModel = RaceModel[identity.currentUser.race];
    $scope.Math = Math;
    $scope.troopsModel = TroopsModel;
    $scope.shipsModel = ShipsModel;
    $scope.upgradesModel = UpgradesModel;

    $scope.upgradeOptions = [];
    for (var i = 0; i < UpgradesModel.multiplier.length; i++) {
        $scope.upgradeOptions.push({
            value: i,
            text: 'Level ' + i + '  (' + Math.round((UpgradesModel.multiplier[i] - 1) * 100) + ' %)'
        });
    }

    $scope.defenderTroops = [0,0,0];
    $scope.defenderGroundUpgrades = [0,0,0];
    $scope.defenderShips = [0,0,0,0];
    $scope.defenderAirUpgrades = [0,0,0];

    $scope.attackerShips = [0,0,0,0];
    $scope.attackerUpgrades = [0,0,0];

    $scope.selectSimulatedTurns = 10;

    if ($rootScope.lastUserObject) {
        $scope.defenderTroops = $rootScope.lastUserObject.troops.slice();
        $scope.defenderShips =  $rootScope.lastUserObject.ships.slice();

        $rootScope.lastUserObject = undefined;
    }

    $scope.simulate = function () {
        var attacker = {
            ships: $scope.attackerShips,
            airUpgrades: $scope.attackerUpgrades
        };
        var defender = {
            troops: $scope.defenderTroops,
            groundUpgrades: $scope.defenderGroundUpgrades,
            ships: $scope.defenderShips,
            airUpgrades: $scope.defenderAirUpgrades
        };

        attacker.ships = [Math.max(attacker.ships[0],0), Math.max(attacker.ships[1],0), Math.max(attacker.ships[2],0), Math.max(attacker.ships[3],0)];
        defender.troops = [Math.max(defender.troops[0],0), Math.max(defender.troops[1],0), Math.max(defender.troops[2],0)];
        defender.ships = [Math.max(defender.ships[0],0), Math.max(defender.ships[1],0), Math.max(defender.ships[2],0), Math.max(defender.ships[3],0)];

        GameRequests.simulateAttack(attacker, defender, $scope.selectSimulatedTurns).then(function(response){
            $scope.simulatedReport = response.report;
        },function(error) {
            console.log('error fetching simulated report ' + error);
        })
    }
});