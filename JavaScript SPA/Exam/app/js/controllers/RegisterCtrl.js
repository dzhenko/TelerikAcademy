'use strict';

app.controller('RegisterCtrl', ['$scope', '$location', 'auth', 'notifier', 'errorHandler',
    function ($scope, $location, auth, notifier, errorHandler) {
        $scope.register = function (user) {
            if (user.password !== user.confirmPassword) {
                notifier.error('Both passwords should match!');
                return;
            }

            auth.register(user).then(function () {
                notifier.success('Registration successful!');
                $location.path('/');
            }, errorHandler)
        }
    }]);