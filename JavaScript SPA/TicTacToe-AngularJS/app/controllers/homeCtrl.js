'use strict';

app.controller("HomeCtrl", function($scope, game, $location, $interval, errorHandler) {
    $scope.welcome = "Start playing or check our users";

    $scope.createGame = function() {
        game.create().then(function(data) {
            data = data.substring(1, data.length - 1);
            $scope.modalWindow = {
                title: 'Game Created',
                text: 'Game Id : ' + data,
                btnText: 'Ok'
            };
            $interval(function() {
                game.status(data).then(function(status) {
                    if (status.State == 1 || status.State == 2) {
                        $location.path('/play-game/' + data);
                    }
                }, errorHandler)
            }, 1000);
        }, errorHandler)
    };

    $scope.joinGame = function() {
        game.join().then(function(data) {
            data = data.substring(1, data.length - 1);
            $location.path('play-game/' + data);
        }, errorHandler)
    }
});