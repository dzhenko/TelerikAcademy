'use strict';

app.directive('dateTimePicker', function() {
    return {
        restrict: 'AC',
        link: function(scope, element, attr) {
            element.kendoDateTimePicker();
        },
        scope: true,
    };
});