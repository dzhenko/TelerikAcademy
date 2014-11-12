app.factory('notifier', function(toastr) {
    'use strict';

    return {
        success: function(msg) {
            toastr.success(msg);
        },
        error: function(msg) {
            toastr.error(msg);
        }
    }
});