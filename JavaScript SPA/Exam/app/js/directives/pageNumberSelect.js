'use strict';

app.directive('pageNumberSelect', function() {
    return {
        restrict: 'AC',
        templateUrl: 'views/directives/page-number-select.html',
        scope: true,
        replace: true
    };
});