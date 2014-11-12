'use strict';

app.controller("MainNavCtrl", function($scope, $location, identity, auth, errorHandler) {
    function refreshMenu() {
        $scope.showLogoutMenu = identity.isAuthenticated();
        $scope.showLoginMenu = !identity.isAuthenticated();
    }

    refreshMenu();

    $scope.$on('loggedInEvent', function(event, args) {
        console.log('heard');
        $scope.login(args.username, args.password);
    });

    $scope.login = function(username, password) {
        auth.login(username, password).then(function(data) {
            identity.loginUser(username, data.access_token);

            refreshMenu();

            $location.path('/home');
        }, errorHandler);
    };

    $scope.logout = function() {
        auth.logout(identity.getToken()).then(function(){
            identity.logoutUser();

            refreshMenu();

            $location.path('/register');
        },errorHandler);
    }
});