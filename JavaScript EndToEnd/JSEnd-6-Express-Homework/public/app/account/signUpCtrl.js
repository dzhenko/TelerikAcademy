app.controller('SignUpCtrl', function ($scope, $location, auth, notifier) {
    'use strict';

    $scope.user = {};

    $scope.signup = function (user) {
        auth.signup(user).then(function () {
            notifier.success('Registration successful !');
            $location.path('/');

        }, function() {
            notifier.error('This username already exists !');
        });
    };

    $scope.changeRace = function (race) {
        $scope.user.race = race;

        $('body').removeClass('zerg-back').removeClass('protoss-back').removeClass('terran-back').addClass(race + '-back');
    }
});