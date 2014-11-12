'use strict';

app.controller("PlayersCtrl", function($scope, player, errorHandler) {
    player.best().then(function(player) {
        $scope.bestPlayer = player.Username;
        $scope.score = player.Score;
    }, errorHandler)
});