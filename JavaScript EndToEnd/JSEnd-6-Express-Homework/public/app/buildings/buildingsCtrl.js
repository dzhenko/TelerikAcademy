app.controller('BuildingsCtrl',
    function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, BuildingsModel, Calculator, notifier, GameRequests) {
        'use strict';

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.buildingsModel = BuildingsModel;

        queryGameObjects();

        // the client queries himself every X or 30 sec. The server is queried only once per 2 min
        $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
        $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

        function queryGameObjects() {
            GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                $scope.filteredTasks = objects.tasks
                    .filter(function (obj) {
                        return obj.type == 'buildings'
                    });

                $scope.gameObjects = objects;

                $scope.now = ((new Date()).getTime());

                $scope.freeEnergy = Calculator.freeEnergy(objects);
                $scope.freeSupply = Calculator.freeSupply(objects);
                $scope.mineralsPerMinute = Calculator.mineralsPerMinute(objects);
                $scope.gasPerMinute = Calculator.gasPerMinute(objects);

                refreshCosts();

                refreshButtons();
            })
        }

        function refreshCosts() {
            $scope.buildingCost = [];

            for (var i = 0; i < BuildingsModel.length; i++) {
                $scope.buildingCost.push(Calculator.requiredResources($scope.gameObjects, 'buildings', i));
                $scope.buildingCost[i].time = Calculator.convertToTime($scope.buildingCost[i].time);
            }
        }

        function refreshButtons() {
            $scope.btnClass = [];
            $scope.btnText = [];
            $scope.btnDisabled = [];

            for (var i = 0; i < BuildingsModel.length; i++) {
                if ($scope.filteredTasks.length > 0) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Building in progress');
                    $scope.btnDisabled.push(true);
                    continue;
                }
                else if ($scope.gameObjects.buildings[i] == BuildingsModel[i].cost.length - 1) {
                    $scope.btnClass.push('btn-success');
                    $scope.btnText.push('Max level');
                    $scope.btnDisabled.push(true);
                }

                var canAfford = Calculator.canAffordBuilding($scope.gameObjects, i);

                if (canAfford.answer) {
                    $scope.btnClass.push('btn-success');
                    $scope.btnText.push('Build');
                    $scope.btnDisabled.push(false);
                }
                else {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push(canAfford.reason);
                    $scope.btnDisabled.push(true);
                }
            }
        }

        var buildingIndex = -1;
        $scope.confirm = function (index) {
            buildingIndex = index;
            $scope.confirmerText = 'Building the ' + $scope.raceModel.buildings[index].name
                + Calculator.requiredResourcesMessage($scope.gameObjects, 'buildings', index);
        };

        $scope.confirmerAccept = function () {
            GameRequests.createTask('buildings', buildingIndex).then(function (response) {
                if (response.success) {
                    notifier.success('Building started');
                    GameObjectsCache.refresh();
                    queryGameObjects();
                }
                else {
                    notifier.error('Not enough minerals or energy');
                }
            }, function (error) {
                console.log(error)
            })
        };
    });