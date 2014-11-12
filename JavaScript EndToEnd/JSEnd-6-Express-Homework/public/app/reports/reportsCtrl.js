app.controller('ReportsCtrl', function ($scope, GameRequests, identity, RaceModel) {
    'use strict';

    var currentReports = JSON.parse(localStorage.getItem('novcraft-userobjects-userreports-'+identity.currentUser._id)) || [];

    GameRequests.getUserReports().then(function (responce) {
        var newReports = currentReports.concat(responce.allReports);
        localStorage.setItem('novcraft-userobjects-userreports-'+identity.currentUser._id, JSON.stringify(newReports));

        $scope.allReports = newReports;

    }, function (error) {
        console.log(error);
    });

    $scope.raceModel = RaceModel[identity.currentUser.race];
    $scope.Math = Math;

    $scope.deleteReport = function(index) {
        $scope.allReports.splice(index,1);
        localStorage.setItem('novcraft-userobjects-userreports-'+identity.currentUser._id, JSON.stringify($scope.allReports));
    };

    $scope.viewReport = function (index) {
        $scope.selectedReport = $scope.allReports[$scope.allReports.length - index - 1];
        $scope.attackerClass = $scope.selectedReport.own ? 'text-success' : 'text-danger';
        $scope.defenderClass = $scope.selectedReport.own ? 'text-danger' : 'text-success';
        $scope.attackerPanelClass = $scope.selectedReport.own ? 'panel-success' : 'panel-danger';
        $scope.defenderPanelClass = $scope.selectedReport.own ? 'panel-danger' : 'panel-success';
        $scope.attackerPanelHeading = $scope.selectedReport.own ? 'Units killed' : 'Lost units';
        $scope.defenderPanelHeading = $scope.selectedReport.own ? 'Lost units' : 'Units killed';
    }
});