'use strict';

app.controller("PlayGameCtrl", function($scope, $routeParams, game, $interval, errorHandler) {
    $interval(function () {
        game.status($routeParams.id).then(function(data) {
            $scope.board = data.Board;
            $scope.state = data.State;
            $scope.firstPlayer = data.FirstPlayerName;
            $scope.secondPlayer = data.SecondPlayerName;
        }, errorHandler)
    }, 1000);

    $scope.clicked = function(row, col){
        game.play({
            GameId : $routeParams.id,
            Row : row,
            Col : col
        });
    }
});