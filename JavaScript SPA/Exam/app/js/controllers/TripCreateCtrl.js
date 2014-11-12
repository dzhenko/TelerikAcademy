'use strict';

app.controller('TripCreateCtrl', ['$scope', '$location', 'notifier', 'appData', 'identity', 'errorHandler',
    function($scope, $location, notifier, appData, identity, errorHandler) {
        appData.userInfo(identity.getAuthorizationToken()).then(function(userInfo) {
            if (!userInfo.isDriver) {
                notifier.error('Only drivers can create trips!');
                $location.path('/trips')
            }

            appData.cities().then(function(data) {
                $scope.cities = data;
            }, errorHandler);

            $scope.createTrip = function(trip) {
                if (trip.availableSeats < 1) {
                    notifier.error('You must have at least one seat!');
                    return;
                }

                if (Date.parse(trip.departureTime) < (new Date()).getTime()) {
                    notifier.error('Departure date should be in the futire!');
                    return;
                }

                appData.createTrip(trip, identity.getAuthorizationToken()).then(function(data){
                    notifier.success('Trip created!');
                    $location.path('/trips');
                }, errorHandler)
            }
        }, errorHandler);
    }]);