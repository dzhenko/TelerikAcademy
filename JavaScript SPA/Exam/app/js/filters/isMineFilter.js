'use strict';

app.filter('isMineFilter', function() {
    return function(isMine) {
        if (isMine) {
            return '<span class="glyphicon glyphicon-ok text-success"></span>';
        }
        else {
            return '<span class="glyphicon glyphicon-remove text-danger"></span>';
        }
    }
});