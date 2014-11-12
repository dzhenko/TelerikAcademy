app.controller('LoginCtrl', function ($scope, $rootScope, $location, notifier, identity, auth, GameObjectsCache) {
    'use strict';

    $scope.identity = identity;

    $scope.login = function (user) {
        auth.login(user).then(function (success) {
            if (success) {
                $rootScope.objectsRefreshSeconds = localStorage.getItem('novcraft-usersettings-refreshrate-'+identity.currentUser._id) || 2;
                notifier.success('Successful login!');
                $('body').removeClass('zerg-back').removeClass('protoss-back').removeClass('terran-back').addClass(identity.currentUser.race + '-back');
                $location.path('/overview')
            }
            else {
                notifier.error('Invalid username or password');
            }
        })
    };

    $scope.logout = function () {
        auth.logout().then(function () {
            window.location.reload(true);
            notifier.success('Successful logout');
            $scope.user = {};
            GameObjectsCache.refresh();
            $location.path('/');
        });
    }
});