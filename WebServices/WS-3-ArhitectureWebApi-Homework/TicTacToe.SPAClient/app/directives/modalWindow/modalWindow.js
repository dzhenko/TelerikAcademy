'use strict';

// modalWindow = title + text + btnHide + btnText + btnClick() (btn hide is the cancel btn
// data-toggle="modal" data-target="#modalWindow" to toggle it
app.directive('modalWindow', function () {
    return {
        restrict: 'A',
        templateUrl: 'app/directives/modalWindow/modal-window.html',
        replace: false
    };
});