app.controller('AttackUserCtrl', function ($scope, $location, $routeParams, ShipsModel, GameObjectsCache, GameRequests, RaceModel , notifier, identity) {
    'use strict';

    $scope.selectTurns = 10;
    $scope.raceModel = RaceModel[identity.currentUser.race];
    $scope.shipsModel = ShipsModel;
    $scope.ships = [0, 0, 0, 0];

    GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
        $scope.userShips = objects.ships;
    });

    $scope.confirm = function () {
        $scope.ships = [Math.max($scope.ships[0],0), Math.max($scope.ships[1],0), Math.max($scope.ships[2],0), Math.max($scope.ships[3],0)];

        $scope.confirmerText = 'Are you sure you want to send';
        for (var i = 0; i < $scope.ships.length; i++) {
            var shipAmmount = $scope.ships[i];
            if (shipAmmount > 0) {
                $scope.confirmerText += ' '+ shipAmmount+ ' ' + $scope.raceModel.ships[i].name + 's,';
            }
        }

        $scope.confirmerText +=' to fight for ' + $scope.selectTurns + ' turns?';
    };

    $scope.confirmerAccept = function () {
        GameRequests.createAttack($routeParams.target, $scope.ships, $scope.selectTurns).then(function(response) {
            if (response.success) {
                notifier.success('Attack sent');
                GameObjectsCache.refresh();
                GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                    $scope.userShips = objects.ships;
                });
            }
            else {
                notifier.error('Not enough minerals or energy');
            }
        }, function(error) {
            console.log(error);
        });
    };
});