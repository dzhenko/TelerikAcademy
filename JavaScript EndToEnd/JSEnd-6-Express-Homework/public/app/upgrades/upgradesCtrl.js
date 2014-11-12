app.controller('UpgradesCtrl',
    function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, BuildingsModel, UpgradesModel, Calculator, notifier, GameRequests) {
        'use strict';

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.buildingsModel = BuildingsModel;
        $scope.upgradesModel = UpgradesModel;
        $scope.Math = Math;

        queryGameObjects();
        //TODO: add link in the attack source coords to scan player

        // the client queries himself every X sec. The server is queried only once per 2 min
        $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
        $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

        function queryGameObjects() {
            GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                $scope.filteredTasks = objects.tasks
                    .filter(function (obj) {
                        return obj.type == 'upgrades'
                    });

                $scope.gameObjects = objects;

                $scope.now = (new Date()).getTime();

                $scope.freeEnergy = Calculator.freeEnergy(objects);
                $scope.freeSupply = Calculator.freeSupply(objects);
                $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
                $scope.gasPerMinute = Calculator.gasPerMinute(objects);

                refreshButtons();
            })
        }

        function refreshButtons() {
            $scope.btnClass = [];
            $scope.btnText = [];
            $scope.btnDisabled = [];

            for (var i = 0; i < UpgradesModel.multiplier.length; i++) {
                if (BuildingsModel[6].amount[$scope.gameObjects.buildings[6]] == 0) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Build ' + $scope.raceModel.buildings[6].name);
                    $scope.btnDisabled.push(true);
                }
                else if ($scope.gameObjects.upgrades[i] == UpgradesModel.multiplier.length - 1) {
                    $scope.btnClass.push('btn-success');
                    $scope.btnText.push('Max level');
                    $scope.btnDisabled.push(true);
                }
                else if ($scope.filteredTasks.length >= BuildingsModel[6].amount[$scope.gameObjects.buildings[6]]) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Upgrade in progress');
                    $scope.btnDisabled.push(true);
                }
                else {
                    var canAfford = Calculator.canAffordUpgrade($scope.gameObjects, i);

                    if (canAfford.answer) {
                        $scope.btnClass.push('btn-success');
                        $scope.btnText.push('Upgrade');
                        $scope.btnDisabled.push(false);
                    }
                    else {
                        $scope.btnClass.push('btn-danger');
                        $scope.btnText.push(canAfford.reason);
                        $scope.btnDisabled.push(true);
                    }
                }
            }
        }

        var upgradesIndex = -1;
        $scope.confirm = function (index) {
            upgradesIndex = index;
            $scope.confirmerText = 'Upgrading the ' + $scope.upgradesModel.names[index].name +
                Calculator.requiredResourcesMessage($scope.gameObjects, 'upgrades', index);
        };

        $scope.confirmerAccept = function () {
            GameRequests.createTask('upgrades', upgradesIndex).then(function (response) {
                if (response.success) {
                    notifier.success('Upgrade started');
                    GameObjectsCache.refresh();
                    queryGameObjects();
                }
                else {
                    notifier.error('Not enough minerals or gas');
                }
            }, function (error) {
                console.log(error)
            })
        };
    });