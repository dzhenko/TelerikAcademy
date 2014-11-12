'use strict';

app.controller("RegisterCtrl", function($scope, $location, $window, identity, auth) {
    $scope.welcome = "Welcome to the most exciting game - Tic Tac Toe !";
    $scope.message = "Start by logging in or signing up";

    $scope.remember = true;

//    $scope.login = function(username, password) {
//        $scope.$emit('loggedInEvent', {
//            username : username,
//            password: password
//        })
//    };

    $scope.register = function(username, password) {
        auth.register(username, password).then(function() {
            $scope.modalWindow = {
                title: 'Successfully registered!',
                text: 'You can now login',
                btnText: 'Ok'
            }
        }, function() {
            $scope.modalWindow = {
                title: 'Username is taken',
                text: 'Try another username',
                btnText: 'Ok'
            }
        });
    };
});