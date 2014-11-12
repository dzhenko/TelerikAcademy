app.controller('OverviewCtrl', function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, UpgradesModel, Calculator) {
    'use strict';

    $scope.raceModel = RaceModel[identity.currentUser.race];
    $scope.raceModel.upgrades = UpgradesModel.names;

    queryGameObjects();

    // the client queries himself every 90 sec. The server is queried only once per 2 min
    $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
    $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

    function queryGameObjects() {
        GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
            $scope.gameObjects = objects;

            $scope.now = (new Date()).getTime();

            $scope.freeEnergy = Calculator.freeEnergy(objects);
            $scope.freeSupply = Calculator.freeSupply(objects);
            $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
            $scope.gasPerMinute = Calculator.gasPerMinute(objects);
        })
    }

    $scope.showAttackInfo = function (index) {
        $scope.additionalInfoHeader = "Attack info";
        $scope.additionalInfoText = 'Your attack consists of';

        for (var i = 0; i < $scope.raceModel.ships.length; i++) {
            if ($scope.gameObjects.attacks[index].ships[i] == 0) {
                continue;
            }
            $scope.additionalInfoText += ' ' + $scope.gameObjects.attacks[index].ships[i] + ' ' + $scope.raceModel.ships[i].name + 's';
        }

        $scope.additionalInfoText += ' and will continue for ' + $scope.gameObjects.attacks[index].turns + ' turns.';
    };

    $scope.showComebackInfo = function (index) {
        $scope.additionalInfoHeader = "Comeback info";
        $scope.additionalInfoText = 'Your comeback consists of';

        for (var i = 0; i < $scope.raceModel.ships.length; i++) {
            if ($scope.gameObjects.comebacks[index].ships[i] == 0) {
                continue;
            }
            $scope.additionalInfoText += ' ' + $scope.gameObjects.comebacks[index].ships[i] + ' ' + $scope.raceModel.ships[i].name + 's';
        }
        //{{ comeback.cargo[0] }} minerals and {{ comeback.cargo[1] }} gas
        $scope.additionalInfoText += ' and has stolen  ' + $scope.gameObjects.comebacks[index].cargo[0] + ' minerals and ' +
            $scope.gameObjects.comebacks[index].cargo[1] + ' gas.';
    }
});