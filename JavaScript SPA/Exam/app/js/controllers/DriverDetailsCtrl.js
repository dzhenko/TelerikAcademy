'use strict';

app.controller('DriverDetailsCtrl', ['$scope', '$routeParams', 'notifier', 'appData','identity', 'errorHandler',
    function($scope, $routeParams, notifier, appData, identity, errorHandler) {
        appData.driverDetails($routeParams.id, identity.getAuthorizationToken())
            .then(function(data){
                $scope.driver = data;
                $scope.tripsToShow = data.trips;
            }, errorHandler);

        $scope.onlyMineTripsValue = true;
        $scope.onlyDriverTripsValue = true;

        $scope.orderByValue = '';

        $scope.orderTypes = [
            {text: 'None', value:''},
            {text:'From', value:'from'},
            {text: 'To', value:'to'},
            {text: 'Departure time', value:'-departureDate'}
        ];

        $scope.filterTrips = function() {
            $scope.tripsToShow = $scope.driver.trips.filter(function(trip){
                if ($scope.onlyMineTripsValue && $scope.onlyDriverTripsValue) {
                    return true;
                }
                else if ($scope.onlyMineTripsValue) {
                    return trip.isMine;
                }
                else if ($scope.onlyDriverTripsValue) {
                    return !trip.isMine;
                }
                else {
                    return false;
                }
            });
        }
    }]);