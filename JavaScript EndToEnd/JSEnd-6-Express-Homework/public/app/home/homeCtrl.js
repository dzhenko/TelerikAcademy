app.controller('HomeCtrl', function($scope, identity) {
    'use strict';
    $scope.hideSignup = identity.isAuthenticated();
});