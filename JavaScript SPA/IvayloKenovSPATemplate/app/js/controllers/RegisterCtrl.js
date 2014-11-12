'use strict';

app.controller('RegisterCtrl', ['$scope', '$location', 'auth', 'notifier', 'errorHandler',
    function ($scope, $location, auth, notifier, errorHandler) {
        $scope.register = function (user) {
            if (user.password !== user.confirmPassword) {
                notifier.error('Both passwords should match!');
                return;
            }

            auth.register(user.email, user.password).then(function () {
                notifier.success('Registration successful!');
                // automatic logging after registration
                auth.login(user.email, user.password).then(function (success) {
                    $location.path('/');
                }, errorHandler)
            }, errorHandler)
        }
    }]);