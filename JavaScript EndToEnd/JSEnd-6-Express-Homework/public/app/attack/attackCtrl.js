app.controller('AttackCtrl', function ($scope, $location, GameRequests, notifier, identity) {
    'use strict';

    $scope.coords = ['', '', ''];
    $scope.targetUsername = '';

    $scope.confirmCoords = function () {
        if (identity.currentUser.coordinates[0] == $scope.coordinates[0] &&
            identity.currentUser.coordinates[1] == $scope.coordinates[1] &&
            identity.currentUser.coordinates[2] == $scope.coordinates[2]) {

            notifier.error('You can not attack yourself');
            return;
        }
        GameRequests.findUserIdByCoords($scope.coords).then(function (id) {
            $location.path('/attack/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };

    $scope.confirmUsername = function () {
        if (identity.currentUser.username == $scope.targetUsername) {
            notifier.error('You can not attack yourself');
            return;
        }
        GameRequests.findUserIdByUsername($scope.targetUsername).then(function (id) {
            $location.path('/attack/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };
});