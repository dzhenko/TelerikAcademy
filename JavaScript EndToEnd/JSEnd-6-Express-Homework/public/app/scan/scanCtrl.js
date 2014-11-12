app.controller('ScanCtrl', function ($scope, $location, $timeout, GameObjectsCache, Calculator, GameRequests, notifier, identity) {
    'use strict';

    $scope.coords = ['','',''];

    GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
        $scope.gameObjects = objects;
        $scope.freeEnergy = Calculator.freeEnergy(objects);
        $scope.freeSupply = Calculator.freeSupply(objects);
        $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
        $scope.gasPerMinute = Calculator.gasPerMinute(objects);

        $scope.scanCost = 'Scanning will cost you ' +
            Calculator.mineralsPerMinute($scope.gameObjects) * 15 + ' minerals and ' +
            Calculator.gasPerMinute($scope.gameObjects) * 15 + ' gas';

        if (Calculator.mineralsPerMinute(objects) * 15 > objects.minerals) {
            $scope.btnText = 'Not enough minerals';
            $scope.btnClass = 'btn-danger';
            $scope.btnDisabled = true;
        }
        else if (Calculator.gasPerMinute(objects) * 15 > objects.gas) {
            $scope.btnText = 'Not enough gas';
            $scope.btnClass = 'btn-danger';
            $scope.btnDisabled = true;
        }
        else {
            $scope.btnText = 'Scan';
            $scope.btnClass = 'btn-success';
            $scope.btnDisabled = false;
        }
    });

    $scope.confirm = function () {
        if (identity.currentUser.coordinates[0] == $scope.coords[0] &&
            identity.currentUser.coordinates[1] == $scope.coords[1] &&
            identity.currentUser.coordinates[2] == $scope.coords[2]) {

            notifier.error('You can not scan yourself');
            return;
        }
        GameRequests.findUserIdByCoords($scope.coords).then(function (id) {
            $location.path('/scan/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };

    $scope.confirmUsername = function () {
        if (identity.currentUser.username == $scope.targetUsername) {
            notifier.error('You can not scan yourself');
            return;
        }
        GameRequests.findUserIdByUsername($scope.targetUsername).then(function (id) {
            $location.path('/scan/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };
});