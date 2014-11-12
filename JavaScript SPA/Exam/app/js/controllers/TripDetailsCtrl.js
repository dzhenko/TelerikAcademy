'use strict';

app.controller('TripDetailsCtrl', ['$scope', '$routeParams', 'notifier', 'appData','identity', 'errorHandler',
    function($scope, $routeParams, notifier, appData, identity, errorHandler) {
        appData.tripDetails($routeParams.id, identity.getAuthorizationToken()).then(function(data){
            $scope.trip = data;
            $scope.passengersInTrip = data.passengers.join(", ");
        }, errorHandler);

        $scope.joinTrip = function() {
            appData.joinTrip($routeParams.id, identity.getAuthorizationToken()).then(function(){
                notifier.success('Trip Joined!');

                //updating the trip details
                appData.tripDetails($routeParams.id, identity.getAuthorizationToken()).then(function(data){
                    $scope.trip = data;
                    $scope.passengersInTrip = data.passengers.join(", ");
                }, errorHandler);
            }, errorHandler);
        }
    }]);