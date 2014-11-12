app.controller('MessageCreateCtrl', function ($scope, $routeParams, GameRequests, notifier) {
    'use strict';

    $('#showMessageInputBtn').click();
    $scope.sendMessage = function() {
        GameRequests.createMessage($routeParams, $scope.textToSend).then(function (response) {
            if (!response.success) {
                notifier.error('Something is bad');
                return;
            }

            notifier.success('Message sent');
        }, function (error) {
            console.log(error)
        });
    };
});