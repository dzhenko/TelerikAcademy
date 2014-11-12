app.controller('ShipsCtrl',
    function ($scope, $rootScope, $interval, GameObjectsCache, RaceModel, identity, BuildingsModel, ShipsModel, Calculator, notifier, GameRequests) {
        'use strict';

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.buildingsModel = BuildingsModel;
        $scope.shipsModel = ShipsModel;

        queryGameObjects();

        //TODO: add link in the attack source coords to scan player

        // the client queries himself every X sec. The server is queried only once per 2 min
        $rootScope.objectsRefreshSeconds = $rootScope.objectsRefreshSeconds || 30;
        $interval(queryGameObjects, 1000 * $rootScope.objectsRefreshSeconds);

        function queryGameObjects() {
            GameObjectsCache.getGameObjectsForUser().$promise.then(function (objects) {
                $scope.filteredTasks = objects.tasks
                    .filter(function (obj) {
                        return obj.type == 'ships'
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

            for (var i = 0; i < ShipsModel.time.length; i++) {
                if (BuildingsModel[5].amount[$scope.gameObjects.buildings[5]] == 0) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Build ' + $scope.raceModel.buildings[5].name);
                    $scope.btnDisabled.push(true);
                }
                else if ($scope.filteredTasks.length >= BuildingsModel[5].amount[$scope.gameObjects.buildings[5]]) {
                    $scope.btnClass.push('btn-danger');
                    $scope.btnText.push('Building in progress');
                    $scope.btnDisabled.push(true);
                }
                else {
                    var canAfford = Calculator.canAffordShip($scope.gameObjects, i);

                    if (canAfford.answer) {
                        $scope.btnClass.push('btn-success');
                        $scope.btnText.push('Construct');
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

        var shipIndex = -1;
        $scope.confirm = function (index) {
            shipIndex = index;
            $scope.confirmerText = 'Constructing this ' + $scope.raceModel.ships[index].name +
                Calculator.requiredResourcesMessage($scope.gameObjects, 'ships', index);
        };

        $scope.confirmerAccept = function () {
            GameRequests.createTask('ships', shipIndex).then(function (response) {
                if (response.success) {
                    notifier.success('Ship construction started');
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