'use strict';

app.controller('TripsCtrl', ['$scope', 'notifier', 'appData', 'identity', 'errorHandler',
    function($scope, notifier, appData, identity, errorHandler) {
        $scope.showIsMineColumn = identity.isAuthenticated();
        $scope.isUserAuthenticated = identity.isAuthenticated();

        appData.lastTrips().then(function(data){
            $scope.trips = data;
        }, errorHandler);

        appData.cities().then(function(data) {
            $scope.cities = data;
        }, errorHandler);

        $scope.sortTypes = [
            {text: 'Driver', value: 'driver'},
            {text: 'Date', value: 'date'},
            {text: 'Number of free seats', value: 'seats'}
        ];

        $scope.orderTypes = [
            {text: 'Ascending', value: 'asc'},
            {text: 'Descending', value: 'desc'}
        ];

        $scope.pageNumber = 1;

        $scope.decreasePage = function() {
            if ($scope.pageNumber > 1) {
                $scope.pageNumber--;
            }
        };

        $scope.increasePage = function() {
            $scope.pageNumber++;
        };

        $scope.filterResults = function () {
            appData.filterTrips($scope.pageNumber, $scope.sortValue, $scope.orderValue, $scope.fromValue, $scope.toValue,
                $scope.includeFinished, $scope.onlyMine, identity.getAuthorizationToken()).then(function(data){
                    $scope.trips = data;
                    $scope.noResultsFound = data.length === 0;
            }, errorHandler);
        };
    }]);