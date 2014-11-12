'use strict';

app.directive('driversTable', function() {
    return {
        restrict: 'AC',
        templateUrl: 'views/directives/driversTable.html',
        scope: true,
        replace: true
    };
});