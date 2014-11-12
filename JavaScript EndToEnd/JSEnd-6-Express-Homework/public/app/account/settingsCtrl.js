app.controller('SettingsCtrl', function ($scope, $location, identity, auth, notifier, $rootScope) {
    'use strict';

    $scope.user = identity.currentUser;

    $scope.refreshRate = $rootScope.objectsRefreshSeconds;

    $scope.hidePasswordInputs = true;
    $scope.showPassword = function () {
        $scope.user.password = '';
        $scope.hidePasswordInputs = false;
    };

    $scope.update = function (user) {
        auth.update(user).then(function () {
            $scope.firstName = user.firstName;
            $scope.lastName = user.lastName;
            notifier.success('Update successful !');
            $location.path('/overview');
        })
    };

    $scope.updateRefreshRate = function (rate) {
        $rootScope.objectsRefreshSeconds = rate;
        $scope.refreshRate = rate;
        localStorage.setItem('novcraft-usersettings-refreshrate-' + identity.currentUser._id, rate);

        notifier.success('Update successful !');
        $location.path('/overview');
    }
});