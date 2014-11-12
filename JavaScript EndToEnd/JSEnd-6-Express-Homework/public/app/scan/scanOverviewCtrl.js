app.controller('ScanOverviewCtrl', function ($scope, $routeParams, $rootScope, GameRequests, RaceModel , notifier, identity) {
    'use strict';

    GameRequests.scanUser($routeParams.target).then(function (response) {
        if (!response.success) {
            notifier.error('Not enough resources for a scan');
            return;
        }

        notifier.success('Scan was successful');

        $scope.raceModel = RaceModel[identity.currentUser.race];
        $scope.enemy = response.targetObjects;

        $rootScope.lastUserObject = $scope.enemy;

    }, function (error) {
        console.log(error)
    });
});