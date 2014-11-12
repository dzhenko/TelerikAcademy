app.controller('MapCtrl', function ($scope, GameRequests, identity, RaceModel) {
    'use strict';

    $scope.raceModel = RaceModel[identity.currentUser.race];
    GameRequests.getAllUsers().then(function (users) {
        $scope.allUsers = users.filter(function (user) {
            return user.username !== identity.currentUser.username;
        });
    }, function (error) {
        console.log(error);
    });
});