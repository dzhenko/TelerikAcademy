app.controller('MessageCtrl', function ($scope, $location, $timeout, GameObjectsCache, Calculator, GameRequests, notifier, identity) {
    'use strict';

    $scope.confirm = function () {
        if (identity.currentUser.coordinates[0] == $scope.coords[0] &&
            identity.currentUser.coordinates[1] == $scope.coords[1] &&
            identity.currentUser.coordinates[2] == $scope.coords[2]) {

            notifier.error('You can not write to yourself');
            return;
        }
        GameRequests.findUserIdByCoords($scope.coords).then(function (id) {
            $location.path('/message-create/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };

    $scope.confirmUsername = function () {
        if (identity.currentUser.username == $scope.targetUsername) {
            notifier.error('You can not write to yourself');
            return;
        }
        GameRequests.findUserIdByUsername($scope.targetUsername).then(function (id) {
            $location.path('/message-create/' + id);

        }, function (error) {
            notifier.error(error);
        });
    };
});