'use strict';

app.directive('tripsTable', function() {
    return {
        restrict: 'AC',
        templateUrl: 'views/directives/tripsTable.html',
        scope: true,
        replace: true
    };
});