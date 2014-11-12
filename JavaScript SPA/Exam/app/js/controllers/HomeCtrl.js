'use strict';

app.controller('HomeCtrl', ['$scope', 'notifier', 'appData', 'appStatisticsCache', 'errorHandler',
    function ($scope, notifier, appData, appStatisticsCache, errorHandler) {
        appStatisticsCache.stats().then(function (data) {
            $scope.tripsCount = data.trips;
            $scope.finishedTripsCount = data.finishedTrips;
            $scope.usersCount = data.users;
            $scope.driversCount = data.drivers;
        }, errorHandler);

        appData.lastTrips().then(function(data){
            $scope.trips = data;
        }, errorHandler);

        appData.lastDrivers().then(function(data){
            $scope.drivers = data;
        }, errorHandler);
    }]);