'use strict';

app.controller('DriversCtrl', ['$scope', 'notifier', 'appData','identity', 'errorHandler',
    function($scope, notifier, appData, identity, errorHandler) {
        appData.lastDrivers().then(function(data){
            $scope.drivers = data;
        }, errorHandler);

        $scope.pageNumber = 1;

        $scope.isUserAuthenticated = identity.isAuthenticated();

        $scope.filterResults = function (username) {
            if (!username || username==='') {
                notifier.error('Username can not be empty');
                return;
            }

            appData.filterDrivers($scope.nameFilter, $scope.pageNumber, identity.getAuthorizationToken())
                .then(function(data){
                    $scope.drivers = data;
                    $scope.noResultsFound = data.length === 0;
                },errorHandler);
        };

        $scope.decreasePage = function() {
            if ($scope.pageNumber > 1) {
                $scope.pageNumber--;
            }
        };

        $scope.increasePage = function() {
            $scope.pageNumber++;
        };
}]);