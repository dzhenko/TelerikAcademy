app.controller('ProfileCtrl', function($scope, identity) {
    'use strict';

    $scope.user = {
        username: identity.currentUser.username,
        firstName: identity.currentUser.firstName,
        lastName: identity.currentUser.lastName
    }
});