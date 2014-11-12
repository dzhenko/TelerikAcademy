app.controller('TroopsCtrl',
    function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, BuildingsModel, TroopsModel, Calculator, notifier, GameRequests) {
        'use strict';

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.buildingsModel = BuildingsModel;
        $scope.troopsModel = TroopsModel;

        queryGameObjects();
        //TODO: add link in the attack source coords to scan player

        // the client queries himself every X sec. The server is queried only once per 2 min
        $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
        $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

        function queryGameObjects() {
            GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                $scope.filteredTasks = objects.tasks
                    .filter(function (obj) {
                        return obj.type == 'troops'
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

            for (var i = 0; i < TroopsModel.time.length; i++) {
                if (BuildingsModel[4].amount[$scope.gameObjects.buildings[4]] == 0) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Build ' + $scope.raceModel.buildings[4].name);
                    $scope.btnDisabled.push(true);
                }
                else if ($scope.filteredTasks.length >= BuildingsModel[4].amount[$scope.gameObjects.buildings[4]]) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Training in progress');
                    $scope.btnDisabled.push(true);
                }
                else {
                    var canAfford = Calculator.canAffordTroop($scope.gameObjects, i);

                    if (canAfford.answer) {
                        $scope.btnClass.push('btn-success');
                        $scope.btnText.push('Train');
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

        var troopsIndex = -1;
        $scope.confirm = function (index) {
            troopsIndex = index;
            $scope.confirmerText = 'Training this ' + $scope.raceModel.troops[index].name +
                Calculator.requiredResourcesMessage($scope.gameObjects, 'troops', index);
        };

        $scope.confirmerAccept = function () {
            GameRequests.createTask('troops', troopsIndex).then(function (response) {
                if (response.success) {
                    notifier.success('Unit construction started');
                    GameObjectsCache.refresh();
                    queryGameObjects();
                }
                else {
                    notifier.error('Not enough minerals, gas or supply');
                }
            }, function (error) {
                console.log(error)
            })
        };
    });